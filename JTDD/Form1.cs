using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace JTDD
{
    public partial class LoadingSetting : Form
	{
        public OpenFileDialog file1 = new OpenFileDialog();
        public OpenFileDialog file2 = new OpenFileDialog();
        public OpenFileDialog file3 = new OpenFileDialog();
        public StreamReader sr1; // 读入XML文件
        public StreamReader sr2;
        public StreamReader sr3;
        public Boolean Fileopen = false;
        public Boolean Fileopen2 = false;
        public Boolean Fileopen3 = false;
        public JsonTextWriter jtw;
        public String[] ans = new String[100];
        public int[] ans2 = new int[100];
        public ProgressBar pgb = new ProgressBar();
        public Timer timed = new Timer();
        public LoadingSetting()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
        //button2:浏览文件
        private void button2_Click(object sender, EventArgs e)
        {
            file1.Filter = "比赛设置文件(*.lgx)|*.lgx";
            if (file1.ShowDialog() == DialogResult.OK)
            {
                String file = file1.FileName;
                textBox1.Text = file;
                //Todo: Status + Log
                Fileopen = true;
            }
        }
        private void showDataInRound(IEnumerable<XElement> elements)
        {
            List<SettingModel> modelList = new List<SettingModel>();
            foreach(var ele in elements)
            {
                SettingModel model = new SettingModel();
 
            }
        }
        public String[] SplitString(String str)
        {
            int length = str.Length;
            //int RHand = 0;
            int q = 0;
            String strtq = str;
            ans = new String[100];
            while (strtq.Contains("|") == true)
            {
                int t = strtq.IndexOf('|');
                String t3 = strtq.Substring(0, t);
                ans[q] = t3;
                q++;
                strtq = strtq.Remove(0, t + 1);
            }
            if (strtq != "")
            {
                ans[q] = strtq;
            }
            return ans;
        }

        public int[] SplitString(String str,int t)
        {
            int length = str.Length;
            //int RHand = 0;
            int q = 0;
            String strtq = str;
            ans = new String[100];
            ans2 = new int[100];
            int t2 = 0;
            while (strtq.Contains("|") == true)
            {
                t2 = strtq.IndexOf('|');
                String t3 = strtq.Substring(0, t2);
                ans[q] = t3;
                q++;
                strtq = strtq.Remove(0, t2 + 1);
            }
            if (strtq != "")
            {
                ans[q] = strtq;
            }
            for (int i = 0; i <= q; i++)
            {
                ans2[i] = Convert.ToInt32(ans[i]);
            }
            return ans2;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           if (Fileopen && Fileopen2 && Fileopen3)
            {
               try
              {
                    pgb.Maximum = 120;
                    sr1 = File.OpenText(file1.FileName);
                    XElement xe = XElement.Load(sr1);
                    CenterExchange.mainsetting.Name = xe.Element("general").Attribute("name").Value.ToString();
                    CenterExchange.SettingLoadingReal = "General.Name";
                    pgb.Value = 10; Application.DoEvents();
                CenterExchange.mainsetting.Type = Convert.ToInt16(xe.Element("general").Attribute("type").Value.ToString());
                    CenterExchange.SettingLoadingReal = "General.Type(Int)";
                    pgb.Value = pgb.Value + 10; Application.DoEvents();
                CenterExchange.mainsetting.Field = Convert.ToInt16(xe.Element("general").Attribute("field").Value.ToString());
                    CenterExchange.SettingLoadingReal = "Genetal.Field(Int)";
                    pgb.Value = pgb.Value + 10; Application.DoEvents();
                CenterExchange.mainsetting.Grade = Convert.ToInt16(xe.Element("general").Attribute("grade").Value.ToString());
                    CenterExchange.SettingLoadingReal = "General.Grade(Int)";
                    pgb.Value = pgb.Value + 10; Application.DoEvents();
                CenterExchange.mainsetting.Round = Convert.ToInt16(xe.Element("general").Element("round").Value.ToString());
                    CenterExchange.SettingLoadingReal = "General.round(node , Int)";
                    pgb.Value = pgb.Value + 10;
                Application.DoEvents();
                CenterExchange.mainsetting.ClassNum = Convert.ToInt16(xe.Element("general").Element("classnum").Value.ToString());
                    CenterExchange.SettingLoadingReal = "General.classnum(Node , Int)";
                    pgb.Value = pgb.Value + 10;
                Application.DoEvents();
                CenterExchange.mainsetting.Attclass = xe.Element("general").Element("attclass").Value.ToString();
                    CenterExchange.SettingLoadingReal = "General.attclass(Node , Int)";
                    pgb.Value = pgb.Value + 10;
                Application.DoEvents();
                CenterExchange.mainsetting.BaseScore = Convert.ToInt32(xe.Element("general").Element("basescore").Value.ToString());
                    CenterExchange.SettingLoadingReal = "General.basescore(Node , Int)";
                    pgb.Value = pgb.Value + 10;
                Application.DoEvents();
                IEnumerable<XElement> rml = from ele in xe.Element("roundlist").Elements("round2") select ele;
                    List<RoundModel> RDL = new List<RoundModel>();
                    foreach (var ele in rml)
                    {
                        RoundModel rm = new RoundModel();
                        rm.Code = Convert.ToInt32(ele.Attribute("code").Value);
                        rm.Name = ele.Element("name").Value;
                        rm.Note = ele.Element("note").Value;
                        rm.TimeElapse = Convert.ToInt32(ele.Element("timeelapse").Value);
                        rm.ScoreR = Convert.ToInt32(ele.Element("scoreR").Value);
                        rm.ScoreW = Convert.ToInt32(ele.Element("scoreW").Value);
                        rm.Type = Convert.ToInt32(ele.Element("type").Value);
                        if (rm.Type == 2)
                        {
                            rm.TypeGroup = true;
                            string t1;
                            t1 = ele.Element("typegroup").Element("name").Value;
                            /*
                            ///<summary>
                            /// 强行调用
                            int length = t1.Length;
                            //int RHand = 0;
                            int q = 0;
                            String strtq = t1;
                            ans = new String[100];
                            while (strtq.Contains("|") == true)
                            {
                                int t = strtq.IndexOf('|');
                                String t3 = strtq.Substring(0, t);
                                ans[q] = t3;
                                q++;
                                strtq = strtq.Remove(0, t + 1);
                            }
                            if (strtq != "")
                            {
                                ans[q] = strtq;
                            }
                            /// </summary>*/
                            rm.GroupName = SplitString(t1);
                            rm.GroupNum = Convert.ToInt32(ele.Element("typegroup").Element("num").Value);
                            t1 = ele.Element("typegroup").Element("scoreR").Value;
                            /*/// <summary>
                            /// 强行调用
                            /// 
                            length = t1.Length;
                            //int RHand = 0;
                            q = 0;
                            strtq = t1;
                            ans = new String[100];
                            ans2 = new int[100];
                            int t2 = 0;
                            while (strtq.Contains("|") == true)
                            {
                                t2 = strtq.IndexOf('|');
                                String t3 = strtq.Substring(0, t2);
                                ans[q] = t3;
                                q++;
                                strtq = strtq.Remove(0, t2 + 1);
                            }
                            if (strtq != "")
                            {
                                ans[q] = strtq;
                            }
                            for (int i = 0; i < q; i++)
                            {
                                ans2[i] = Convert.ToInt32(ans[i]);
                            }*/
                            rm.GroupScoreR = SplitString(t1,0);
                            /// </summary>
                            t1 = ele.Element("typegroup").Element("scoreW").Value;
                           /* /// <summary>
                            /// 强行调用
                            /// 
                            length = t1.Length;
                            //int RHand = 0;
                            q = 0;
                            strtq = t1;
                            ans = new String[100];
                            ans2 = new int[100];
                            t2 = 0;
                            while (strtq.Contains("|") == true)
                            {
                                t2 = strtq.IndexOf('|');
                                String t3 = strtq.Substring(0, t2);
                                ans[q] = t3;
                                q++;
                                strtq = strtq.Remove(0, t2 + 1);
                            }
                            if (strtq != "")
                            {
                                ans[q] = strtq;
                            }
                            for (int i = 0; i < q; i++)
                            {
                                ans2[i] = Convert.ToInt32(ans[i]);
                            }*/
                            rm.GroupScoreW = SplitString(t1, 0);
                            /// </summary>
                        }
                        else  if (rm.Type == 7){
                            rm.TypeGroup = true;
                            string t1;
                            t1 = ele.Element("typegroup").Element("name").Value;
                            /*
                            ///<summary>
                            /// 强行调用
                            int length = t1.Length;
                            //int RHand = 0;
                            int q = 0;
                            String strtq = t1;
                            ans = new String[100];
                            while (strtq.Contains("|") == true)
                            {
                                int t = strtq.IndexOf('|');
                                String t3 = strtq.Substring(0, t);
                                ans[q] = t3;
                                q++;
                                strtq = strtq.Remove(0, t + 1);
                            }
                            if (strtq != "")
                            {
                                ans[q] = strtq;
                            }
                            /// </summary>*/
                            rm.GroupName = SplitString(t1);
                            rm.GroupNum = Convert.ToInt32(ele.Element("typegroup").Element("num").Value);
                            t1 = ele.Element("typegroup").Element("scoreR").Value;
                            /*/// <summary>
                            /// 强行调用
                            /// 
                            length = t1.Length;
                            //int RHand = 0;
                            q = 0;
                            strtq = t1;
                            ans = new String[100];
                            ans2 = new int[100];
                            int t2 = 0;
                            while (strtq.Contains("|") == true)
                            {
                                t2 = strtq.IndexOf('|');
                                String t3 = strtq.Substring(0, t2);
                                ans[q] = t3;
                                q++;
                                strtq = strtq.Remove(0, t2 + 1);
                            }
                            if (strtq != "")
                            {
                                ans[q] = strtq;
                            }
                            for (int i = 0; i < q; i++)
                            {
                                ans2[i] = Convert.ToInt32(ans[i]);
                            }*/
                            rm.GroupScoreR = SplitString(t1, 0);
                            /// </summary>
                            t1 = ele.Element("typegroup").Element("scoreW").Value;
                            /* /// <summary>
                             /// 强行调用
                             /// 
                             length = t1.Length;
                             //int RHand = 0;
                             q = 0;
                             strtq = t1;
                             ans = new String[100];
                             ans2 = new int[100];
                             t2 = 0;
                             while (strtq.Contains("|") == true)
                             {
                                 t2 = strtq.IndexOf('|');
                                 String t3 = strtq.Substring(0, t2);
                                 ans[q] = t3;
                                 q++;
                                 strtq = strtq.Remove(0, t2 + 1);
                             }
                             if (strtq != "")
                             {
                                 ans[q] = strtq;
                             }
                             for (int i = 0; i < q; i++)
                             {
                                 ans2[i] = Convert.ToInt32(ans[i]);
                             }*/
                            rm.GroupScoreW = SplitString(t1, 0);
                            /// </summary>
                        }
                        else
                        {
                            rm.TypeGroup = false;
                        }
                        RDL.Add(rm);
                    }
                    CenterExchange.mainsetting.RoundData = RDL;
                    pgb.Value = pgb.Maximum;
                    CenterExchange.SettingLoadingReal = "";

                    ///<summary>
                    /// File2 Load:二级配置文件读入
                    /// 格式XML
                    /// </summary>
                    sr2 = File.OpenText(file3.FileName);
                    // XML configuration Reading
                    // Method : Linq
                    xe = XElement.Load(file3.FileName);
                    IEnumerable<XElement> elements = from ele in xe.Elements("compd")
                                                     select ele;
                    int g = 0;
                    foreach (var ele in elements)
                    {
                        CenterExchange.Competition[g, 0] = ele.Element("num").Value;
                        CenterExchange.Competition[g, 1] = ele.Element("ident").Value;
                        g++;
                    }
                    IEnumerable<XElement> elements2 = from ele in xe.Elements("ctype")
                                                      select ele;
                    g = 0;
                    foreach (var ele in elements2)
                    {
                        CenterExchange.TypeD[g, 0] = ele.Element("num").Value;
                        CenterExchange.TypeD[g, 1] = ele.Element("ident").Value;
                        g++;
                    }

                    // 读入题库文件
                    sr3 = File.OpenText(file2.FileName);
                    xe = XElement.Load(file2.FileName);
                    IEnumerable<XElement> elements3 = from ele in xe.Elements("exercise")
                                                      select ele;
                    foreach(var ele in elements3)
                    {
                        ExerciseModel model = new ExerciseModel();
                        model.ID = Convert.ToInt32(ele.Attribute("ID").Value);
                        model.Avail = Convert.ToBoolean(ele.Attribute("Available").Value);
                        model.Fir_type = Convert.ToInt32(ele.Attribute("First_Type").Value);
                        model.Sec_type = Convert.ToInt32(ele.Attribute("Second_Type").Value);
                        model.Stem = ele.Element("Stem").Value;
                        model.Key = ele.Element("Key").Value;
                        model.Ca = ele.Element("ChoiceA").Value;
                        model.Cb = ele.Element("ChoiceB").Value;
                        model.Cc = ele.Element("ChoiceC").Value;
                        model.Cd = ele.Element("ChoiceD").Value;
                        model.ScoreR = Convert.ToInt32(ele.Element("ScoreR").Value);
                        model.ScoreW = Convert.ToInt32(ele.Element("ScoreW").Value);
                        CenterExchange.mainExer.Add(model);
                    }
                CenterExchange.totExer = Convert.ToInt32(xe.Element("TotalExercise").Value);
                DialogResult dr;
                pgb.Value = pgb.Maximum;
                dr = MessageBox.Show("读取完成", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                  }
                catch (Exception)
                {
                     // TODO : 归并到UIBridge.ExceptionShow
                     DialogResult dr;
                     dr = MessageBox.Show("错误1：读取" + CenterExchange.SettingLoadingReal + "错误!", "文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                 }
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Count() ==1)
            {
                // TODO : 归并到UIBridge.ExceptionShow
                DialogResult dr;
                dr = MessageBox.Show("错误11：扩展显示屏错误或者未连接扩展显示屏，请检查！", "显示错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Output opt = new Output();
                OuputControl optc = new OuputControl();
                CenterExchange.OutputMode = 1;
                UICore.InitSubTitle();
                opt.Show();
                optc.Show();
                opt.Location = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
                this.Hide();
            }
        }

        private void halte_Click(object sender, EventArgs e)
        {

            Environment.Exit(0);
        }

        private void LoadingSetting_Load(object sender, EventArgs e)
        {
            pgb = progressBar1;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CenterExchange.SettingLoadingReal != "")
            {
                Status.Text = "正在读取节点：" + CenterExchange.SettingLoadingReal;
            } else
            {
                Status.Text = "读取结束。";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            file2.Filter = "题库配置文件(*.xml)|*.xml";
            if (file2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = file2.FileName;
                //Todo: Status + Log
                Fileopen2 = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            file3.Filter = "二级配置文件(*.xml)|*.xml";
            if (file3.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = file3.FileName;
                //Todo: Status + Log
                Fileopen3 = true;
            }
        }
    }
}
