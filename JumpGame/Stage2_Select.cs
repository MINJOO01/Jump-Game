using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage2_Select : Form
    {
        public Stage2_Select()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stage2_EasyMode S2Easy = new Stage2_EasyMode();
            S2Easy.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stage2_HardMode S2Hard = new Stage2_HardMode();
            S2Hard.Show();
            this.Hide();
        }
    }
}
