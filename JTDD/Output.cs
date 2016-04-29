using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace JTDD
{
    public partial class Output : Form
    {
        public Label[] bases = new Label[5];
        public Label[] classes = new Label[5];
        public static int[] L = { 51, 236, 435, 630, 825 };
        public static int[] R = { 198, 382, 583, 775, 975 };
        public Output()
        {
            InitializeComponent();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void InitLabel()
        {
            for(int i = 0; i < 5; i++)
            {
                bases[i].ForeColor = Color.White;
                classes[i].ForeColor = Color.White;
                if (CenterExchange.FirstRun == true) {
                    CenterExchange.ActData.ClassScore[i] = CenterExchange.mainsetting.BaseScore;
                    CenterExchange.FirstRun = false;
                } 
                bases[i].Text = CenterExchange.ActData.ClassScore[i].ToString();
                classes[i].Text = CenterExchange.ActData.ClassLabel[i];
            }
            /*for(int i = 0; i < 5; i++)
            {

                bases[i].Left = (R[i] + L[i]) / 2 - (bases[i].Size.Width / 2);
                classes[i].Left = (R[i] + L[i]) / 2 - (classes[i].Size.Width / 2);
            }*/
            
        }
        private void panel_1024_Paint(object sender, PaintEventArgs e)
        {
            comp_title.Left = (1024 - comp_title.Size.Width) / 2;
            comp_type.Left = 1024 - comp_type.Size.Width - 85;
            Boolean f = SetFormFullScreen(true);
            if (CenterExchange.Final)
            {
                comp_round.Text = "本次比赛前2名 " + CenterExchange.ActData.ClassLabel[4] + "  " + CenterExchange.ActData.ClassLabel[3];

            }
            else
            {
                comp_round.Text = "本次比赛共 " + CenterExchange.mainsetting.Round + " 轮。";
            }
            label1.ForeColor = Color.White;
            comp_round.ForeColor = Color.White;
            bases[0] = sc51;
            bases[1] = sc52;
            bases[2] = sc53;
            bases[3] = sc54;
            bases[4] = sc55;
            classes[0] = c51;
            classes[1] = c52;
            classes[2] = c53;
            classes[3] = c54;
            classes[4] = c55;
            comp_title.Text = CenterExchange.mainsetting.Name;
            comp_type.Text = CenterExchange.SubTitle;
            if(CenterExchange.mainsetting.ClassNum == 4)
            {
                bases[4].Visible = false;
                classes[4].Visible = false;
                InitLabel();
            } else
            {
                InitLabel();
            }
        }
        public Boolean SetFormFullScreen(Boolean fullscreen)//ref Rectangle rectOld
        {
            Rectangle rectOld = Rectangle.Empty;
            Int32 hwnd = 0;
            hwnd = FindWindow("Shell_TrayWnd", null);//获取任务栏的句柄

            if (hwnd == 0) return false;

            if (fullscreen)//全屏
            {
                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get  屏幕范围
                Rectangle rectFull = Screen.AllScreens[1].Bounds;//全屏范围：扩展屏
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//窗体全屏幕显示
            }
            else//还原 
            {
                //ShowWindow(hwnd, SW_SHOW);//显示任务栏

                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//窗体还原
            }
            return true;
        }

        #region user32.dll

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern Int32 ShowWindow(Int32 hwnd, Int32 nCmdShow);
        public const Int32 SW_SHOW = 5;
        public const Int32 SW_HIDE = 0;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, ref Rectangle lpvParam, Int32 fuWinIni);
        public const Int32 SPIF_UPDATEINIFILE = 0x1;
        public const Int32 SPI_SETWORKAREA = 47;
        public const Int32 SPI_GETWORKAREA = 48;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern Int32 FindWindow(string lpClassName, string lpWindowName);

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = System.DateTime.Now.ToString("yyyy-M-dd HH:mm:ss");
            if (CenterExchange.CloseFlag == 2)
            {
                CenterExchange.CloseFlag = 0;
                this.Hide();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}

