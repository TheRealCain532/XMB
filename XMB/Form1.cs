using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using XMB.Properties;

namespace XMB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Settings.Default.IP != "")
                textBox1.Text = Settings.Default.IP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("PS3"))
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse(textBox1.Text), 80));
                socket.Send(Encoding.ASCII.GetBytes("GET /pad.ps3?psbtn HTTP/1.1\nHost: localhost\nContent-Length: 512\n\r\n\r\n"));
                socket.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.IP = textBox1.Text;
            Settings.Default.Save();
        }
    }
}
