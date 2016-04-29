using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JTDD
{
    public partial class OuputControl : Form
    {
        //public Label[] RoundShow = new Label[9];
        public Label[] scores = new Label[5];
        public Label[] classes = new Label[5];
        public Output opt = new Output();
        public MD cpt = new MD();
        public Color background = Color.FromArgb(192, 255, 255);
        public OuputControl()
        {
            InitializeComponent();
        }
        public void Exchange(string a, string b)
        {
            string t;
            t = a;a = b;b = t;
        }
        public void Exchange(int a, int b)
        {
            int t;
            t = a; a = b; b = t;
        }
        private void SortClass()
        {
            for(int i = 0; i < CenterExchange.mainsetting.ClassNum; i++)
            {
                for(int j= i; j < CenterExchange.mainsetting.ClassNum; j++)
                {
                    if (CenterExchange.ActData.ClassScore[i] > CenterExchange.ActData.ClassScore[j])
                    {
                        int t;
                        t = CenterExchange.ActData.ClassScore[i];
                        CenterExchange.ActData.ClassScore[i] = CenterExchange.ActData.ClassScore[j];
                        CenterExchange.ActData.ClassScore[j] = t;
                        string t2;
                        t2 = CenterExchange.ActData.ClassLabel[i];
                        CenterExchange.ActData.ClassLabel[i] = CenterExchange.ActData.ClassLabel[j];
                        CenterExchange.ActData.ClassLabel[j] = t2;
                    }
                }
            }
        }
        private void OuputControl_Load(object sender, EventArgs e)
        {
            scores[0] = label16;
            scores[1] = label17;
            scores[2] = label18;
            scores[3] = label19;
            scores[4] = label20;
            classes[0] = label11;
            classes[1] = label12;
            classes[2] = label13;
            classes[3] = label14;
            classes[4] = label15;
            for (int i = 0; i < 5; i++)
            {
                scores[i].Text = CenterExchange.ActData.ClassScore[i].ToString();
                classes[i].Text = CenterExchange.ActData.ClassLabel[i];
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CenterExchange.OutputMode == 1)
            {
                label1.Text = "当前状态：准备阶段屏幕输出";
            } else if (CenterExchange.OutputMode == 2)
            {
                label1.Text = "当前状态：比赛阶段屏幕输出";
                for (int i = 0; i < 5; i++)
                {
                    scores[i].Text = CenterExchange.ActData.ClassScore[i].ToString();
                    classes[i].Text = CenterExchange.ActData.ClassLabel[i];
                    cpt.ClassScore[i].Text = CenterExchange.ActData.ClassScore[i].ToString();
                    cpt.ClassLabel[i].Text = CenterExchange.ActData.ClassLabel[i];
                }
            }

        }
        private void ClearClass()
        {
            for (int i = 0; i < 5; i++)
            {
                cpt.panel[i].BackColor = background;
            }
        }
        private void ClearExer()
        {
            cpt.MB.BackColor = background;
            cpt.MC.BackColor = background;
            cpt.textBox3.BackColor = background;
            cpt.MA.BackColor = background;
            cpt.AAnswer.BackColor = background;
            cpt.AStem.BackColor = background;
        }
        private void SelectClass(int n, int p, int m)
        {
            if (n >= 0) {
                cpt.panel[n].BackColor = Color.Yellow;
            };
            if (p >= 0) { cpt.panel[p].BackColor = Color.LightBlue; }
            if (m >= 0) { cpt.panel[m].BackColor = background; }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ///<summary>
            /// 跳转至某一轮
            /// </summary>
            int q = Convert.ToInt32(numericUpDown1.Value);
            CenterExchange.Real_Round = q;
            if (q > CenterExchange.mainsetting.Round)
            {
                DialogResult dr;
                dr = MessageBox.Show("错误9：跳转目标轮数大于总轮数", "设置错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } else
            {
                textBox1.Text = CenterExchange.mainsetting.RoundData[q - 1].Name;
                textBox2.Text = CenterExchange.mainsetting.RoundData[q - 1].TimeElapse.ToString();
                for (int i = 0; i < 10; i++)
                {
                    if (CenterExchange.Competition[i, 0] == CenterExchange.mainsetting.RoundData[q-1].Type.ToString())
                    { String te = CenterExchange.Competition[i, 1]; textBox3.Text = te; i = 10; }
                }
                textBox4.Text = CenterExchange.mainsetting.RoundData[q - 1].ScoreR.ToString()
                    + " | " + CenterExchange.mainsetting.RoundData[q - 1].ScoreW.ToString();
                CenterExchange.ScoreR = CenterExchange.mainsetting.RoundData[q - 1].ScoreR;
                CenterExchange.ScoreW = CenterExchange.mainsetting.RoundData[q - 1].ScoreW;
                String tq;
                String td;
                tq = CenterExchange.mainsetting.RoundData[q - 1].Note;
                int t = tq.IndexOf("\\r\\n");
                String t3 = tq.Substring(0, t);
                td = t3.Trim();
                tq = tq.Remove(0, t + 5);
                while (tq.Contains("\\r\\n") == true)
                {
                    t = tq.IndexOf("\\r\\n");
                    t3 = tq.Substring(0, t);
                    td = td + Environment.NewLine + t3.Trim();
                    tq = tq.Remove(0, t + 5);
                }
                td = td.Trim() + Environment.NewLine + tq.Trim();
                textBox5.Text = td;
                cpt.Description.Visible = true;
                cpt.Answering.Visible = false;
                cpt.Multiple.Visible = false;
                cpt.Choose.Visible = false;
                cpt.Description.Text = CenterExchange.mainsetting.RoundData[q - 1].Name + Environment.NewLine + td;
                label3.Text = "状态：第" + q.ToString() + "轮";
                CenterExchange.CountDownStandard = Convert.ToInt32(textBox2.Text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //OuputControl optc = new OuputControl();
            CenterExchange.OutputMode = 1;
            //UICore.InitSubTitle();
            opt.Show();
            //optc.Show();
            opt.Location = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
            CenterExchange.CloseFlag = 1;
            CenterExchange.OutputMode = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            cpt.Show();
            cpt.Location = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
            CenterExchange.CloseFlag = 2;
            CenterExchange.OutputMode = 2;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            cpt.Description.Text = textBox5.Text + Environment.NewLine + textBox5.Text;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 0;
            if(CenterExchange.mainsetting.RoundData[CenterExchange.Real_Round-1].Type == 1)
            {
                cpt.Multiple.Visible = true;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = false;
                cpt.Choose.Visible = false;
                CenterExchange.ExerCur = 0;
                textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                cpt.MStem.Text = textBox6.Text;
                cpt.MA.Text = textBox7.Text;
                cpt.MB.Text = textBox8.Text;
                cpt.MC.Text = textBox9.Text;
                cpt.textBox3.Text = textBox10.Text;
                SelectClass(CenterExchange.ClassCur, -1, -1);
            }
            if (CenterExchange.mainsetting.RoundData[CenterExchange.Real_Round - 1].Type == 2)
            {
                cpt.Multiple.Visible = false;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = false;
                cpt.Choose.Visible = true;
                CenterExchange.ExerCur = 0;
                /*textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                cpt.MStem.Text = textBox6.Text;
                cpt.MA.Text = textBox7.Text;
                cpt.MB.Text = textBox8.Text;
                cpt.MC.Text = textBox9.Text;
                cpt.textBox3.Text = textBox10.Text;*/
                cpt.Sort1.Text = CenterExchange.TypeD[2, 1];
                cpt.Sort2.Text = CenterExchange.TypeD[3, 1];
                cpt.Sort3.Text = CenterExchange.TypeD[4, 1];
                cpt.Sort4.Text = CenterExchange.TypeD[5, 1];
                cpt.Sort5.Text = CenterExchange.TypeD[6, 1];
                cpt.Sort6.Text = CenterExchange.TypeD[7, 1];
                button25.Text = cpt.Sort1.Text;
                button26.Text = cpt.Sort2.Text;
                button27.Text = cpt.Sort3.Text;
                button28.Text = cpt.Sort4.Text;
                button29.Text = cpt.Sort5.Text;
                button30.Text = cpt.Sort6.Text;
                SelectClass(CenterExchange.ClassCur, -1, -1);
            }
            if (CenterExchange.mainsetting.RoundData[CenterExchange.Real_Round - 1].Type == 3)
            {
                cpt.Multiple.Visible = false;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = true;
                cpt.Choose.Visible = false;
                CenterExchange.ExerCur = 22;
                /*textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                cpt.MStem.Text = textBox6.Text;
                cpt.MA.Text = textBox7.Text;
                cpt.MB.Text = textBox8.Text;
                cpt.MC.Text = textBox9.Text;
                cpt.textBox3.Text = textBox10.Text;*/
                String t3 = CenterExchange.mainExer[CenterExchange.ExerCur].Stem.Substring(0, CenterExchange.mainExer[CenterExchange.ExerCur].Stem.Length / 2);
                CenterExchange.HalfStem = t3;
                cpt.AStem.Text = CenterExchange.HalfStem;
                textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                textBox8.Text = "半题干：" + cpt.AStem.Text;
                SelectClass(CenterExchange.ClassCur, -1, -1);
                CenterExchange.ClassCurR3 = CenterExchange.ClassCur;
            }
            if (CenterExchange.mainsetting.RoundData[CenterExchange.Real_Round - 1].Type == 4)
            {
                cpt.Multiple.Visible = false;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = false;
                cpt.Choose.Visible = true;
                CenterExchange.ExerCur = 0;
                CenterExchange.ClassCur = 0;
                /*textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                cpt.MStem.Text = textBox6.Text;
                cpt.MA.Text = textBox7.Text;
                cpt.MB.Text = textBox8.Text;
                cpt.MC.Text = textBox9.Text;
                cpt.textBox3.Text = textBox10.Text;*/
                cpt.Sort1.Text = "10分";
                cpt.Sort2.Text = "20分";
                cpt.Sort3.Text = "30分";
                cpt.Sort4.Text = "40分";
                cpt.Sort5.Text = "50分";
                cpt.Sort1.Visible = true;
                cpt.Sort2.Visible = true;
                cpt.Sort3.Visible = true;
                cpt.Sort4.Visible = true;
                cpt.Sort5.Visible = true;
                cpt.Sort6.Visible = false;
                button25.Text = cpt.Sort1.Text;
                button26.Text = cpt.Sort2.Text;
                button27.Text = cpt.Sort3.Text;
                button28.Text = cpt.Sort4.Text;
                button29.Text = cpt.Sort5.Text;
                button30.Text = "Null";
                SelectClass(CenterExchange.ClassCur, -1, -1);
                button43.Text = CenterExchange.ActData.ClassLabel[0];
                button44.Text = CenterExchange.ActData.ClassLabel[1];
                button45.Text = CenterExchange.ActData.ClassLabel[2];
                button46.Text = CenterExchange.ActData.ClassLabel[3];
                button47.Text = CenterExchange.ActData.ClassLabel[4];
                button48.Text = CenterExchange.ActData.ClassLabel[0];
                button49.Text = CenterExchange.ActData.ClassLabel[1];
                button50.Text = CenterExchange.ActData.ClassLabel[2];
                button51.Text = CenterExchange.ActData.ClassLabel[3];
                button52.Text = CenterExchange.ActData.ClassLabel[4];
                cpt.AAnswer.Text = "";
                cpt.AStem.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(CenterExchange.CountDownReal == 0)
            {
                timer2.Enabled = false;
                CenterExchange.CountDownReal = 0;
                cpt.countdownA.Text = "0";
                cpt.countdownB.Text = "0";
            }
            else
            {
                cpt.countdownA.Text = ((int)(CenterExchange.CountDownReal / 10) + 1).ToString();
                cpt.countdownB.Text = ((int)(CenterExchange.CountDownReal / 10) + 1).ToString();
                CenterExchange.CountDownReal--;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (textBox16.Text.Contains('A') == true)
            {
                cpt.MA.BackColor = Color.Green;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.mainExer[CenterExchange.ExerCur].ScoreR;
            } else
            {
                cpt.MA.BackColor = Color.Red;
                if (textBox16.Text.Contains('B') == true) { cpt.MB.BackColor = Color.Green; }
                if (textBox16.Text.Contains('C') == true) { cpt.MC.BackColor = Color.Green; }
                if (textBox16.Text.Contains('D') == true) { cpt.textBox3.BackColor = Color.Green; }
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.mainExer[CenterExchange.ExerCur].ScoreW;
            }

        }

        private void button32_Click(object sender, EventArgs e)
        {
            CenterExchange.CountDownReal = CenterExchange.CountDownStandard - 1;
            timer2.Enabled = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (textBox16.Text.Contains('B') == true)
            {
                cpt.MB.BackColor = Color.Green;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.mainExer[CenterExchange.ExerCur].ScoreR;
            }
            else
            {
                cpt.MB.BackColor = Color.Red;
                if (textBox16.Text.Contains('A') == true) { cpt.MA.BackColor = Color.Green; }
                if (textBox16.Text.Contains('C') == true) { cpt.MC.BackColor = Color.Green; }
                if (textBox16.Text.Contains('D') == true) { cpt.textBox3.BackColor = Color.Green; }
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                          CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.mainExer[CenterExchange.ExerCur].ScoreW;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (textBox16.Text.Contains('D') == true)
            {
                cpt.textBox3.BackColor = Color.Green;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                       CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.mainExer[CenterExchange.ExerCur].ScoreR;
            }
            else
            {
                cpt.textBox3.BackColor = Color.Red;
                if (textBox16.Text.Contains('A') == true) { cpt.MA.BackColor = Color.Green; }
                if (textBox16.Text.Contains('C') == true) { cpt.MC.BackColor = Color.Green; }
                if (textBox16.Text.Contains('B') == true) { cpt.MB.BackColor = Color.Green; }
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.mainExer[CenterExchange.ExerCur].ScoreW;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (textBox16.Text.Contains('C') == true)
            {
                cpt.MC.BackColor = Color.Green;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.mainExer[CenterExchange.ExerCur].ScoreR;
            }
            else
            {
                cpt.MC.BackColor = Color.Red;
                if (textBox16.Text.Contains('A') == true) { cpt.MA.BackColor = Color.Green; }
                if (textBox16.Text.Contains('B') == true) { cpt.MB.BackColor = Color.Green; }
                if (textBox16.Text.Contains('D') == true) { cpt.textBox3.BackColor = Color.Green; }
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                                    CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.mainExer[CenterExchange.ExerCur].ScoreW;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[0] = Convert.ToInt32(textBox11.Text);
            CenterExchange.ActData.ClassScore[1] = Convert.ToInt32(textBox12.Text);
            CenterExchange.ActData.ClassScore[2] = Convert.ToInt32(textBox13.Text);
            CenterExchange.ActData.ClassScore[3] = Convert.ToInt32(textBox14.Text);
            CenterExchange.ActData.ClassScore[4] = Convert.ToInt32(textBox15.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 1)
            {
                CenterExchange.ExerCur++;
                CenterExchange.ClassCur = (CenterExchange.ClassCur + 1) % 5;
                textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                cpt.MStem.Text = textBox6.Text;
                cpt.MA.Text = textBox7.Text;
                cpt.MB.Text = textBox8.Text;
                cpt.MC.Text = textBox9.Text;
                cpt.textBox3.Text = textBox10.Text;
                ClearClass();
                ClearExer();
                SelectClass(CenterExchange.ClassCur, -1, -1);

            }
            if (CenterExchange.Real_Round == 2)
            {
                CenterExchange.mainExer[CenterExchange.ExerCur].Avail = false;
                CenterExchange.ClassCur = (CenterExchange.ClassCur + 1) % 5;
                ClearClass();
                ClearExer();
                SelectClass(CenterExchange.ClassCur, -1, -1);
                cpt.Choose.Visible = true;
                cpt.Multiple.Visible = false;
                if (CenterExchange.mainExer[11].Avail == false) { cpt.Sort1.Visible = false; }
                if (CenterExchange.mainExer[13].Avail == false) { cpt.Sort2.Visible = false; }
                if (CenterExchange.mainExer[15].Avail == false) { cpt.Sort3.Visible = false; }
                if (CenterExchange.mainExer[17].Avail == false) { cpt.Sort4.Visible = false; }
                if (CenterExchange.mainExer[19].Avail == false) { cpt.Sort5.Visible = false; }
                if (CenterExchange.mainExer[21].Avail == false) { cpt.Sort6.Visible = false; }
            }
            if (CenterExchange.Real_Round == 3)
            {
                ClearClass();
                ClearExer();
                CenterExchange.ClassCurR3++;
                CenterExchange.ClassCur = CenterExchange.ClassCurR3 % 5;
                cpt.Multiple.Visible = false;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = true;
                cpt.Choose.Visible = false;
                CenterExchange.ExerCur++; cpt.AAnswer.Text = "";
                cpt.AStem.Text = "";
                String t3 = CenterExchange.mainExer[CenterExchange.ExerCur].Stem.Substring(0, CenterExchange.mainExer[CenterExchange.ExerCur].Stem.Length / 2);
                CenterExchange.HalfStem = t3;
                cpt.AStem.Text = CenterExchange.HalfStem;
                textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                textBox8.Text = "半题干：" + cpt.AStem.Text;
                SelectClass(CenterExchange.ClassCur, -1, -1);
            }
            if (CenterExchange.Real_Round == 4)
            {
                ClearClass();
                ClearExer();
                cpt.Multiple.Visible = false;
                cpt.Description.Visible = false;
                cpt.Answering.Visible = false;
                cpt.Choose.Visible = true;
                cpt.AAnswer.Text = "";
                cpt.AStem.Text = "";
                cpt.Sort1.Visible = true;
                cpt.Sort2.Visible = true;
                cpt.Sort3.Visible = true;
                cpt.Sort4.Visible = true;
                cpt.Sort5.Visible = true;
                CenterExchange.mainExer[CenterExchange.ExerCur].Avail = false;
                if (CenterExchange.mainExer[33].Avail == false) { cpt.Sort1.Visible = false; }
                if (CenterExchange.mainExer[35].Avail == false) { cpt.Sort2.Visible = false; }
                if (CenterExchange.mainExer[37].Avail == false) { cpt.Sort3.Visible = false; }
                if (CenterExchange.mainExer[39].Avail == false) { cpt.Sort4.Visible = false; }
                if (CenterExchange.mainExer[41].Avail == false) { cpt.Sort5.Visible = false; }
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[10].Avail == false)
                {
                    CenterExchange.ExerCur = 11;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 10;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            if (CenterExchange.Real_Round == 4)
            {
                if (CenterExchange.mainExer[32].Avail == false)
                {
                    CenterExchange.ExerCur = 33;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 10;
                    CenterExchange.ScoreW = 10;
                }
                else
                {
                    CenterExchange.ExerCur = 32;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 10;
                    CenterExchange.ScoreW = 10;
                }
            }
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[12].Avail == false)
                {
                    CenterExchange.ExerCur = 13;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 12;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            if (CenterExchange.Real_Round == 4)
            {
                if (CenterExchange.mainExer[34].Avail == false)
                {
                    CenterExchange.ExerCur = 35;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 20;
                    CenterExchange.ScoreW = 20;
                }
                else
                {
                    CenterExchange.ExerCur = 34;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 20;
                    CenterExchange.ScoreW = 20;
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[14].Avail == false)
                {
                    CenterExchange.ExerCur = 15;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 14;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            if (CenterExchange.Real_Round == 4)
            {
                if (CenterExchange.mainExer[36].Avail == false)
                {
                    CenterExchange.ExerCur = 35;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 30;
                    CenterExchange.ScoreW = 30;
                }
                else
                {
                    CenterExchange.ExerCur = 36;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 30;
                    CenterExchange.ScoreW = 30;
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[16].Avail == false)
                {
                    CenterExchange.ExerCur = 17;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 16;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            if (CenterExchange.Real_Round == 4)
            {
                if (CenterExchange.mainExer[38].Avail == false)
                {
                    CenterExchange.ExerCur = 39;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 40;
                    CenterExchange.ScoreW = 40;
                }
                else
                {
                    CenterExchange.ExerCur = 38;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 40;
                    CenterExchange.ScoreW = 40;
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[18].Avail == false)
                {
                    CenterExchange.ExerCur = 19;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 18;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            if (CenterExchange.Real_Round == 4)
            {
                if (CenterExchange.mainExer[40].Avail == false)
                {
                    CenterExchange.ExerCur = 41;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 50;
                    CenterExchange.ScoreW = 50;
                }
                else
                {
                    CenterExchange.ExerCur = 40;
                    cpt.Choose.Visible = false;
                    cpt.Answering.Visible = true;
                    cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    CenterExchange.ScoreR = 50;
                    CenterExchange.ScoreW = 50;
                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (CenterExchange.Real_Round == 2)
            {
                if (CenterExchange.mainExer[20].Avail == false)
                {
                    CenterExchange.ExerCur = 21;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
                else
                {
                    CenterExchange.ExerCur = 20;
                    cpt.Choose.Visible = false;
                    cpt.Multiple.Visible = true;
                    textBox6.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
                    textBox7.Text = "A." + CenterExchange.mainExer[CenterExchange.ExerCur].Ca;
                    textBox8.Text = "B." + CenterExchange.mainExer[CenterExchange.ExerCur].Cb;
                    textBox9.Text = "C." + CenterExchange.mainExer[CenterExchange.ExerCur].Cc;
                    textBox10.Text = "D." + CenterExchange.mainExer[CenterExchange.ExerCur].Cd;
                    textBox16.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
                    cpt.MStem.Text = textBox6.Text;
                    cpt.MA.Text = textBox7.Text;
                    cpt.MB.Text = textBox8.Text;
                    cpt.MC.Text = textBox9.Text;
                    cpt.textBox3.Text = textBox10.Text;
                }
            }
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            cpt.Answering.Visible = false;
            cpt.Multiple.Visible = false;
            cpt.Choose.Visible = false;
            cpt.Description.Visible = false;
            ClearClass();
            ClearExer();
            SortClass();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            cpt.AStem.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Stem;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            int q;
            q = Convert.ToInt32(numericUpDown2.Value);
            CenterExchange.ScoreR = q;
            CenterExchange.ScoreW = q;
            cpt.AStem.Text = "（本题" + q.ToString().Trim() + "分）" + CenterExchange.HalfStem;
            textBox8.Text = cpt.AStem.Text;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            cpt.AAnswer.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
            cpt.AAnswer.BackColor = Color.Green;
            if (CenterExchange.Real_Round == 3)
            {
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                       CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.ScoreR;
            }
            if (CenterExchange.Real_Round == 4)
            {
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCurR4] =
                       CenterExchange.ActData.ClassScore[CenterExchange.ClassCurR4] + CenterExchange.ScoreR;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                      CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.ScoreW;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            cpt.AAnswer.Text = CenterExchange.mainExer[CenterExchange.ExerCur].Key;
            cpt.AAnswer.BackColor = Color.Red;
            if (CenterExchange.Real_Round == 3)
            {
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                      CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] - CenterExchange.ScoreW;
            }
            if (CenterExchange.Real_Round == 4)
            {
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] =
                       CenterExchange.ActData.ClassScore[CenterExchange.ClassCur] + CenterExchange.ScoreR;
                CenterExchange.ActData.ClassScore[CenterExchange.ClassCurR4] =
                      CenterExchange.ActData.ClassScore[CenterExchange.ClassCurR4] - CenterExchange.ScoreW;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 0;
            ClearClass();
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 1;
            ClearClass();
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 2;
            ClearClass();
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 3;
            ClearClass();
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 4;
            ClearClass();
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SortClass();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[0] = CenterExchange.ActData.ClassScore[0] + 5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[0] = CenterExchange.ActData.ClassScore[0] - 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[1] = CenterExchange.ActData.ClassScore[1] + 5;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[1] = CenterExchange.ActData.ClassScore[1] - 5;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[2] = CenterExchange.ActData.ClassScore[2] + 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[2] = CenterExchange.ActData.ClassScore[2] - 5;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[3] = CenterExchange.ActData.ClassScore[3] + 5;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[3] = CenterExchange.ActData.ClassScore[3] - 5;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[4] = CenterExchange.ActData.ClassScore[4] + 5;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CenterExchange.ActData.ClassScore[4] = CenterExchange.ActData.ClassScore[4] - 5;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 0;
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 1;
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur =2;
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 3;
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCur = 4;
            SelectClass(CenterExchange.ClassCur, -1, -1);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCurR4 = 0;
            SelectClass(-1,CenterExchange.ClassCurR4, -1);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCurR4 = 1;
            SelectClass(-1, CenterExchange.ClassCurR4, -1);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCurR4 = 2;
            SelectClass(-1, CenterExchange.ClassCurR4, -1);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCurR4 = 3;
            SelectClass(-1, CenterExchange.ClassCurR4, -1);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            CenterExchange.ClassCurR4 = 4;
            SelectClass(-1, CenterExchange.ClassCurR4, -1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            CenterExchange.Final = true;
            //OuputControl optc = new OuputControl();
            CenterExchange.OutputMode = 1;            
            //UICore.InitSubTitle();
            opt.Show();
            //optc.Show();
            opt.Location = new Point(Screen.PrimaryScreen.Bounds.Width, 0);
            CenterExchange.CloseFlag = 1;
            CenterExchange.OutputMode = 1;
            opt.comp_round.Text = "本次比赛前2名 " + CenterExchange.ActData.ClassLabel[4] + "  " + CenterExchange.ActData.ClassLabel[3];
            opt.label1.Text = "比赛结束，谢谢观看！请大家有序离场。";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
