using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage1_Result_F : Form
    {
        Point p;
        int x, y;
        int sec;

        public Stage1_Result_F()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            sec = 0;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Enabled = true;
            //360, 330
            x = 360;
            y = 330;
            p = new Point(x, y);
            pictureBox1.Location = p;
            if (sec > 0.5)
            {
                Stage2_Load S2LoadForm = new Stage2_Load();
                S2LoadForm.Show();
                this.Hide();
            }
        }

        private void Stage1_Result_F_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
        }
    }
}
