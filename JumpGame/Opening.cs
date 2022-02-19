using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace JumpGame
{
    public partial class Opening : Form
    {
        public int sec;

        public Opening()
        {
            InitializeComponent();
            sec = 0;
        }



        private void Opening_Load(object sender, EventArgs e)
        { 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec == 10)
            {
                Start startForm = new Start();
                startForm.Show();
                this.Hide();
            }
        }
    }
}
