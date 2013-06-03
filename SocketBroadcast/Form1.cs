using BaseCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketBroadcast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if (this.SocketServer != null)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        while (true)
                        {
                            byte[] MsgBuffer = new byte[65535];
                            var _soket = SocketServer.Accept();

                            this.Clients.Add(_soket);

                            _soket.NoDelay = true;
                            _soket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None,
                                new AsyncCallback((r) => { RecieveCallBack(r, MsgBuffer); }), _soket);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.GetInstance().Error(ex.StackTrace, ex);
                    }
                });

            }

            this.com_Socket.DisplayMember = "key";
            this.com_Socket.ValueMember = "Value";
        }


        List<Socket> Clients = new List<Socket>();
        delegate void delegate_setInfo(Socket item, byte[] value);

        private void RecieveCallBack(IAsyncResult AR, byte[] MsgBuffer)
        {
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);

                byte[] v = MsgBuffer.Take(REnd).ToArray();

                Log.GetInstance().WriteDebugLog("Server_Receive 接收到:" + System.Text.Encoding.Default.GetString(v));
                GetMessage(RSocket, v);
                //同时接收客户端回发的数据，用于回发
                MsgBuffer = new byte[65535];
                RSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback((r) => { RecieveCallBack(r, MsgBuffer); }), RSocket);

            }
            catch (Exception ex)
            {
                Log.GetInstance().Error(ex.Message, ex);
            }
        }

        private void GetMessage(Socket RSocket, byte[] v)
        {
            List<Socket> closed = new List<Socket>();

            foreach (var item in this.Clients)
            {
                if (!item.Connected)
                {
                    closed.Add(item);
                    continue;
                }
                item.Send(v);
            }

            foreach (var item in closed)
            {
                this.Clients.Remove(item);
            }

        }

        private Socket _socket = null;
        public Socket SocketServer
        {
            get
            {
                if (_socket == null)
                {
                    //IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                    //IPAddress local = null;
                    //foreach (IPAddress ip in arrIPAddresses)
                    //{
                    //    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    //    {
                    //        local = ip;
                    //        this.txt_log.AppendText("LocalIP:"+ ip.ToString());
                    //        break;
                    //    }
                    //}

                    //if (local == null)
                    //{
                    //    local = IPAddress.Parse("127.0.0.1");
                    //}

                    //IPAddress.Parse("10.241.204.89")
                    IPEndPoint ipedp = new IPEndPoint(IPAddress.Any, Properties.Settings.Default.Port);
                    _socket = new Socket(ipedp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    SocketServer.Bind(ipedp);
                    SocketServer.Listen(500);
                }

                return _socket;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint ipedp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Properties.Settings.Default.Port);
            Socket client = new Socket(ipedp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(ipedp);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        byte[] buffer = new byte[65535];
                        int count = client.Receive(buffer);
                        GetMessage_Client(client, buffer.Take(count).ToArray());
                    }
                }
                catch (Exception ex)
                {
                    Log.GetInstance().Error("KinectSocketClient_ Receive", ex);
                }

            });

            this.com_Socket.Items.Add(
               new SocketItem() { key = "Client" + this.com_Socket.Items.Count, Value = client }
             );
        }

        private void GetMessage_Client(Socket client, byte[] p)
        {

            if (this.txt_log.InvokeRequired)
            {
                var d = new delegate_setInfo(GetMessage_Client);
                this.Invoke(d, client, p);
            }
            else
            {
                String address = "";
                String port = "";
                if (client != null)
                {
                    IPEndPoint ipEndPoint = (IPEndPoint)client.RemoteEndPoint;
                    if (ipEndPoint != null)
                    {
                        address = ipEndPoint.Address.ToString();
                        port = ipEndPoint.Port.ToString();
                    }

                }

                this.txt_log.AppendText(
                    "{0},socket:{1},value:{2}\n".ExtFormat("",
                    address + ":" + port,
                    System.Text.Encoding.Default.GetString(p))
                    );

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket soc = ((this.com_Socket.SelectedItem) as SocketItem).Value;
            if (soc == null) return;

            soc.Send(System.Text.Encoding.Default.GetBytes("Message" + DateTime.Now.Ticks));

        }
    }
    public class SocketItem
    {
        public string key { get; set; }
        public Socket Value { get; set; }
    }
}
