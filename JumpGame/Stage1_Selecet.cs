using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage1_Selecet : Form
    {
        public Stage1_Selecet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player_PB S1Hard = new player_PB();
            S1Hard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stage1_EasyMode S1Easy = new Stage1_EasyMode();
            S1Easy.Show();
            this.Hide();
        }

        private void Stage1_Selecet_Load(object sender, EventArgs e)
        {
            
        }
    }
}
