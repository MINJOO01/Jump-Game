using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class MainStage : Form
    {
        Point p;
        int x, y;
        int sec;
        public MainStage()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            sec = 0;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //154, 276
            x = 154;
            y = 276;
            p = new Point(x, y);
            pictureBox1.Location = p;
            if (sec > 0.5)
            {
                Stage1_Load S1LoadForm = new Stage1_Load();
                S1LoadForm.Show();
                this.Hide();
            }
        }

        private void MainStage_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
