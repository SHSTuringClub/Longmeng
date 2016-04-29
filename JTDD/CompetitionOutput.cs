using System;
using System.Windows.Forms;

namespace JTDD
{
    public partial class MD : Form
    {
        public Panel[] panel = new Panel[5];
        public Label[] ClassLabel = new Label[5];
        public Label[] ClassScore = new Label[5];
        public TextBox Description;
        public Panel Answering;
        public Panel Multiple;
        public Panel Choose;
        public MD()
        {
            InitializeComponent();
        }

        private void CompetitionOutput_Load(object sender, EventArgs e)
        {
            Description = description;
            Answering = AnsweringPanel;
            Multiple = MultipleChoicePanel;
            Choose = ChoosePanel;
            panel[0] = panel1;
            panel[1] = panel2;
            panel[2] = panel3;
            panel[3] = panel4;
            panel[4] = panel5;
            ClassLabel[0] = c51;
            ClassLabel[1] = label2;
            ClassLabel[2] = label4;
            ClassLabel[3] = label6;
            ClassLabel[4] = label8;
            ClassScore[0] = sc51;
            ClassScore[1] = label1;
            ClassScore[2] = label3;
            ClassScore[3] = label5;
            ClassScore[4] = label7;
            comp_title.Text = CenterExchange.mainsetting.Name;
            comp_type.Text = CenterExchange.SubTitle;
            for (int i = 0; i < 5; i++)
            {
                //bases[i].ForeColor = Color.White;
                //classes[i].ForeColor = Color.White;
                //CenterExchange.ActData.ClassScore[i] = CenterExchange.mainsetting.BaseScore;
                ClassScore[i].Text = CenterExchange.ActData.ClassScore[i].ToString();
                ClassLabel[i].Text = CenterExchange.ActData.ClassLabel[i];
                ClassLabel[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            }
            AnsweringPanel.Visible = false;
            MultipleChoicePanel.Visible = false;
            ChoosePanel.Visible = false;
            description.Visible = false;
            AAnswer.Text = "";
            AStem.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = System.DateTime.Now.ToString("yyyy-M-dd HH:mm:ss");
            if (CenterExchange.CloseFlag == 1)
            {
                CenterExchange.CloseFlag = 0;
                this.Hide();
            }
        }
    }
}
