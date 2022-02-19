using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage2_Result_F : Form
    {
        Point p;
        int x, y;
        int sec;



        public Stage2_Result_F()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            sec = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            //540, 276
            x = 540;
            y = 276;
            p = new Point(x, y);
            pictureBox1.Location = p;
            if (sec > 0.5)
            {
                Stage3_Load S3LoadForm = new Stage3_Load();
                S3LoadForm.Show();
                this.Hide();
            }
            
        }

        private void Stage2_Result_F_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
        }

    }
}
