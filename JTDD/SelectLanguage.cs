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
    public partial class SelectLanguage : Form
    {
        public Button ChineseLanguage = new Button();
        public Button EnglishLanguage = new Button();
        public Button Apply = new Button();
        public SelectLanguage()
        {
            InitializeComponent();
        }

        private void SelectLanguage_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadingSetting ls = new LoadingSetting();
            ls.Show();
           // ShowWindow(hwnd, SW_SHOW);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
