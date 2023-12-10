using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;

namespace Lab7
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var listener = new TcpListener(IPAddress.Any, 5555);
            // ��������� listen����
            listener.Start();
            var socket = listener.AcceptSocket();
            if (socket.Connected)
            {
                var ns = new NetworkStream(socket);
                //������� ����� ��������� ������ ThreadClass 
                ThreadClass threadClass = new ThreadClass();
                //������� ����� �����
                Thread thread = threadClass.Start(ns, threadClass.fileName, threadClass.fileCount, this);
            }
        }
    }
}