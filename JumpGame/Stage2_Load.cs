using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage2_Load : Form
    {
        public int sec;
        public Stage2_Load()
        {
            InitializeComponent();
            sec = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage2_Select S2Select = new Stage2_Select();
                S2Select.Show();
                this.Hide();
            }
        }

        private void Stage2_Load_Load(object sender, EventArgs e)
        {

        }
    }
}
