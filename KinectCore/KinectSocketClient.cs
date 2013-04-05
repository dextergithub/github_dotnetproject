using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KinectCore
{
    public class KinectSocketClient
    {
        public  Socket client { get; set; }

        public event KinectCore.GetMessageHandler GetMessage;

        public KinectSocketClient()
        {

        }

        private void Connected()
        {
            if (this.client != null && this.client.Connected != true) return;
            IPEndPoint ipedp = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerAddress), Properties.Settings.Default.ServerPort);
            this.client = new Socket(ipedp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.client.Connect(ipedp);
            Task.Factory.StartNew(() => {
                try
                {
                    while (true)
                    {
                        byte[] buffer=new byte[65535];
                        int count=this.client.Receive(buffer);
                        if (GetMessage != null) GetMessage(this.client, buffer.Take(count).ToArray());
                    }
                }
                catch (Exception ex)
                {
                    Log.log.Error("KinectSocketClient_ Receive", ex);                    
                }
               
            });
        }

        public void SendMessage(byte[] msg)
        {
            try
            {
                this.Connected();
                if (this.client != null)
                    this.client.Send(msg);
            }
            catch (Exception ex)
            {

                Log.log.Error("KinectSocketClient__ SendMessage", ex);
            }
          

        }
    }
}
