using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage3_Load : Form
    {
        public int sec;
        public Stage3_Load()
        {
            InitializeComponent();
            sec = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage3_Select S3Select = new Stage3_Select();
                S3Select.Show();
                this.Hide();
            }
            }
        }
    }

