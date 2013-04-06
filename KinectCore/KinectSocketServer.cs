using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;

namespace KinectCore
{
    public delegate void GetMessageHandler(Socket socket, byte[] msg);

    public class KinectSocketServer
    {

        public Socket ServerSocket { get; set; }

      
        public event GetMessageHandler GetMessage;


        public KinectSocketServer()
        {
            this.GetMessage += (s, b) => { };

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.LocalAddress), Properties.Settings.Default.LocalPort);
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(localEndPoint);
            ServerSocket.Listen(100);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true)
                    {
                        byte[] MsgBuffer = new byte[65535];
                        var _soket = ServerSocket.Accept();
                        _soket.NoDelay = true;
                        _soket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None,
                            new AsyncCallback((r) => { RecieveCallBack(r, MsgBuffer); }), _soket);
                    }
                }
                catch (Exception ex)
                {
                    Log.log.Error(ex.StackTrace);
                }
            });


        }

        private void RecieveCallBack(IAsyncResult AR, byte[] MsgBuffer)
        {
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);

                byte[] v = MsgBuffer.Take(REnd).ToArray();

                Log.log.WriteDebugLog("Server_Receive 接收到:"+System.Text.Encoding.Default.GetString(v));
                GetMessage(RSocket, v);
                //同时接收客户端回发的数据，用于回发
                MsgBuffer = new byte[65535];
                RSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback((r) => { RecieveCallBack(r, MsgBuffer); }), RSocket);

            }
            catch (Exception ex)
            {
                Log.log.Error(ex.Message, ex);
            }
        }

    }
}
