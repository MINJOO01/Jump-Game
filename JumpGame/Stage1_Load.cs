using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage1_Load : Form
    {
        public int sec;
        public Stage1_Load()
        {
            InitializeComponent();
            sec = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec == 3)
            {
                Stage1_Selecet S1Select = new Stage1_Selecet();
                S1Select.Show();
                this.Hide();
            }
        }

        private void Stage1_Load_Load(object sender, EventArgs e)
        {

        }
    }
}
