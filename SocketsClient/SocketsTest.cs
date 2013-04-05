using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketsClient
{
    public partial class SocketsTest : Form
    {
        public System.Net.Sockets.Socket clientSocket { get; set; }

        public Socket ServerSocket { get; set; }

        System.Threading.Thread th;

        public SocketsTest()
        {
            InitializeComponent();
        }

        private void SetMessage(string message)
        {
            this.label3.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clientSocket != null && this.clientSocket.Connected )
                {
                    return;
                }
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(SocketsClient.Properties.Settings.Default.ServerAddress), SocketsClient.Properties.Settings.Default.Port);
                this.clientSocket = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(ipep);

                ServerSocket.Bind(ipep);

                ServerSocket.Listen(10);

                while (true)
                {

                    clientSocket = ServerSocket.Accept();

                    th = new Thread(new ThreadStart(doWork));

                    th.Start();

                } 


                th = new System.Threading.Thread(() => {
                
                });

            }
            catch (Exception ex)
            {

                SetMessage("发送消息错误！" + ex.Message);
            }
           
        }

        private  void doWork()
        {

            Socket s = clientSocket;//客户端信息 

            IPEndPoint ipEndPoint = (IPEndPoint)s.RemoteEndPoint;

            String address = ipEndPoint.Address.ToString();

            String port = ipEndPoint.Port.ToString();

            Console.WriteLine(address + ":" + port + " 连接过来了");

            Byte[] inBuffer = new Byte[1024];

            Byte[] outBuffer = new Byte[1024];

            String inBufferStr;

            String outBufferStr;

            try
            {

                while (true)
                {

                    s.Receive(inBuffer, 1024, SocketFlags.None);//如果接收的消息为空 阻塞 当前循环  

                    inBufferStr = Encoding.ASCII.GetString(inBuffer);

                    Console.WriteLine(address + ":" + port + "说:");

                    Console.WriteLine(inBufferStr);

                    outBufferStr = Console.ReadLine();

                    outBuffer = Encoding.ASCII.GetBytes(outBufferStr);

                    s.Send(outBuffer, outBuffer.Length, SocketFlags.None);

                }

            }

            catch
            {

                Console.WriteLine("客户端已关闭！");

            }

        } 

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {             


                Byte[] outBuffer  =  Encoding.Default .GetBytes( this.textBox1.Text);    

                    //发送消息  
                    clientSocket.Send(outBuffer, outBuffer.Length, SocketFlags.None);
                    this.textBox1.Text = "";

            }

            catch(Exception ex)
            {

                SetMessage("发送消息错误！"+ ex.Message );

            }
        }

        private void SocketsTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.clientSocket != null)
            {
                if (this.clientSocket.Connected)
                {
                    this.clientSocket.Close();
                }
            }
        }
    }
}
