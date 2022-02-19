using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage2_Result_T : Form
    {
        Point p;
        int x, y;
        int sec;


        public Stage2_Result_T()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            sec = 0;
        }

        private void Stage2_Result_T_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            //542, 283
            x = 542;
            y = 283;
            p = new Point(x, y);
            pictureBox1.Location = p;
            if (sec > 0.5)
            {
                Stage3_Load S3LoadForm = new Stage3_Load();
                S3LoadForm.Show();
                this.Hide();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
        }

    }
}
