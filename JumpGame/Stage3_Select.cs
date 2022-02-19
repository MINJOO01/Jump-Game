using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage3_Select : Form
    {
        public Stage3_Select()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stage3_EasyMode S3Easy = new Stage3_EasyMode();
            S3Easy.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stage3_HardMode S3Hard = new Stage3_HardMode();
            S3Hard.Show();
            this.Hide();
        }
    }
}
