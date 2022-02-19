using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage3_Result_F : Form
    {
        Point p;
        int x, y;
        int sec;


        public Stage3_Result_F()
        {
            InitializeComponent();
            x = pictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            sec = 0;
        }


        private void Stage3_Result_F_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            //645, 107
            x = 645;
            y = 107;
            p = new Point(x, y);
            pictureBox1.Location = p;
            if (sec > 1)
            {

                Ending endForm = new Ending();
                endForm.Show();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
           
        }
    }
}
