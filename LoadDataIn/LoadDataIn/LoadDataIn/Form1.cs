using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LoadDataIn
{
    public partial class Form1 : Form
    {
        public OpenFileDialog file1 = new OpenFileDialog();
        public OpenFileDialog file2 = new OpenFileDialog();
        public SaveFileDialog sfile1 = new SaveFileDialog();
        public Boolean Fileopen = false;
        public Boolean Fileopen2 = false;
        public Boolean Fileopen3 = false;
        public ListView lv = new ListView();
        public int tot = 0;
        public int now = 0;
        public int linen = 0;
        public Boolean totlock = false;
        public StreamReader sr;
        public StreamReader sr2;
        public String[,] Competition = new String[10,2];
        public String[,] TypeD = new String[20, 2];
        public List<Exercise> exerl = new List<Exercise>();
        public int m = 0;
        public Form1()
        {
            InitializeComponent();
            lv = this.listView1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            file1.Filter = "原始题库文件(*.dat)|*.dat";
            if (file1.ShowDialog() == DialogResult.OK)
            {
                String file = file1.FileName;
                textBox1.Text = file;
                //Todo: Status + Log
                Fileopen = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Fileopen)
            {
                ///<summary>
                /// File2 Load:二级配置文件读入
                /// 格式XML
                /// </summary>
                sr2 = File.OpenText(file2.FileName);
                // XML configuration Reading
                // Method : Linq
                XElement xe = XElement.Load(file2.FileName);
                IEnumerable<XElement> elements = from ele in xe.Elements("compd")
                               select ele;
                int g = 0;
                foreach (var ele in elements)
                {
                    Competition[g, 0] = ele.Element("num").Value;
                    Competition[g, 1] = ele.Element("ident").Value;
                    g++;
                }
                IEnumerable<XElement> elements2 = from ele in xe.Elements("ctype")
                                                 select ele;
                g = 0;
                foreach (var ele in elements2)
                {
                    TypeD[g, 0] = ele.Element("num").Value;
                    TypeD[g, 1] = ele.Element("ident").Value;
                    g++;
                }
                ///<summary>
                /// File1 Load:原始题库文件读入
                /// </summary>
                sr = File.OpenText(file1.FileName);
                String St2 = "";
                tot = 0;
                now = 0;
                linen = 0;
                totlock = false;
                while ((St2=sr.ReadLine())!= null)
                {
                    linen++;
                    byte[] buffer = Encoding.UTF8.GetBytes(St2);
                    String St = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    if (!St.StartsWith("###"))
                    {
                        if (St.StartsWith("***"))
                        {
                            try
                            {
                                if(totlock) { sr.Close(); throw (new Exception()); }
                                String t = St.Trim('*').Trim();
                                tot = (int)Convert.ToInt16(t);
                                totlock = true;
                            } catch (Exception ee)
                            {
                                DialogResult dr;
                                dr = MessageBox.Show("在第" + linen.ToString() + "出现重复总题数指令", "文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                break;
                            }
                        } else  {
                            Exercise exer = new Exercise();
                            exer.Avail = true;
                        int length = St.Length;
                        int RHand = 0;
                        int q = 1;
                        String t2 = St;
                        ListViewItem lvt = lv.Items.Add("");
                        while(RHand < length)
                        {
                            int t = t2.IndexOf('|');
                                if (t == -1) {RHand = length + 1; }
                                else {
                                    String t3 = t2.Substring(0, t);
                                   
                                    switch (q)
                                    {
                                        case 1:exer.ID = t3; break;
                                        case 2:exer.Stem = t3; break;
                                        case 3:exer.Key = t3; break;
                                        case 4:exer.Typed = t3; break;
                                        case 5:exer.ChoiceA = t3; break;
                                        case 6: exer.ChoiceB = t3; break;
                                        case 7: exer.ChoiceC = t3; break;
                                        case 8: exer.ChoiceD = t3; break;
                                        case 9:exer.StdType = t3; break;
                                        case 10:exer.ScoreR = t3; break;
                                        case 11:exer.ScoreW = t3; break;
                                        default:break;
                                    }

                                    if (q == 4)
                                    {
                                        for(int i = 0; i < 10; i++)
                                        {
                                            if (Competition[i, 0] == t3) { String tq = Competition[i, 1]; lvt.SubItems.Add(tq); i = 10; }
                                        }
                                    } else if (q == 9)
                                    {
                                        for (int i = 0; i < 20; i++)
                                        {
                                            if (TypeD[i, 0] == t3) { String tq = TypeD[i, 1]; lvt.SubItems.Add(tq); i = 20; }
                                        }
                                    } else if ((q == 5) || (q==6) || (q==7) || (q==8))
                                    {
                                        if(t3=="-37") { lvt.SubItems.Add("  "); }
                                        if (t3 != "-37") { lvt.SubItems.Add(t3); }
                                    } else  { lvt.SubItems.Add(t3); }
                                   
                            RHand = RHand + t;
                            t2 = t2.Remove(0, t + 1);
                                    q++;
                                    
                                }
                            
                        }
                            exerl.Add(exer);
                            Application.DoEvents();
                            lvt.EnsureVisible();
                            now++;
                        }

                    }
                }

                /// <summary>
                /// 写入新文件
                /// </summary>
                XElement xed = XElement.Load(sfile1.FileName);
                m = 1;
                foreach (var ele in exerl)
                {
                    label8.Text = "正在写入第" + m + "题";
                    XElement Record = new XElement(
                        new XElement("exercise",
                        new XAttribute("ID", ele.ID),
                        new XAttribute("Available", ele.Avail),
                        new XAttribute("First_Type", ele.Typed),
                        new XAttribute("Second_Type", ele.StdType),
                        new XElement("Stem", ele.Stem),
                        new XElement("Key",ele.Key),
                        new XElement("ScoreR",ele.ScoreR),
                        new XElement("ScoreW",ele.ScoreW),
                        new XElement("ChoiceA", ele.ChoiceA),
                        new XElement("ChoiceB", ele.ChoiceB),
                        new XElement("ChoiceC", ele.ChoiceC),
                        new XElement("ChoiceD", ele.ChoiceD)));
                    xed.Add(Record);
                    Application.DoEvents();
                    m++;
                }
                XElement Record2 = new XElement("TotalExercise", m-1);
                xed.Add(Record2);
                xed.Save(sfile1.FileName);
                timer1.Enabled = false;
                label8.Text = "写入完成！";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label3.Text = tot.ToString();
            label4.Text = now.ToString();
            label5.Text = linen.ToString();
            label8.Text = "正在写入第" + m + "题";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sr.Close();
            } catch (Exception ee)
            {

            }
            
            System.Environment.Exit(0);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            file2.Filter = "二级配置文件(*.xml)|*.xml";
            if (file2.ShowDialog() == DialogResult.OK)
            {
                String file = file2.FileName;
                textBox2.Text = file;
                //Todo: Status + Log
                Fileopen2 = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sfile1.Filter = "配置文件(*.xml)|*.xml";
            if (sfile1.ShowDialog() == DialogResult.OK)
            {
                String file = sfile1.FileName;
                textBox3.Text = file;
                //Todo: Status + Log
                FileStream fs = (FileStream)sfile1.OpenFile();
                byte[] myByte = System.Text.Encoding.UTF8.GetBytes("<root> </root>");
                fs.Write(myByte,0, myByte.Length);
                fs.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
