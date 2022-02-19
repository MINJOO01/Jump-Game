using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace JumpGame
{
    public partial class Client : Form
    {
        
        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;
        public string nick;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(this.textBox2.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            clientSocket.Connect("127.0.0.1", 9999);
            stream = clientSocket.GetStream();
            message = "Connected to Chat Server";

            DisplayText(message);
            byte[] buffer = Encoding.Unicode.GetBytes(this.textBox3.Text + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();

            textBox3.Enabled = false;
        }

        private void GetMessage()
        {
            while(true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                DisplayText(message);
            }

        }

        private void DisplayText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new MethodInvoker(delegate
                {
                    textBox1.AppendText(text + Environment.NewLine);
                }));
            }
            else
                textBox1.AppendText(text + Environment.NewLine);
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(this, e);
            //엔터키 누른 것 = 버튼 누른 것
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button3_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            nick = textBox3.Text;
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3_Click(this, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainStage MSForm = new MainStage();
            MSForm.Show();
            this.Hide();
        }
    }
}
