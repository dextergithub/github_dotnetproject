using KinectCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace KinectSocketsServer
{
    class Program
    {
      public  static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1333);
            SocketServer objServer = new SocketServer(1000, 10);
            objServer.Init();
            objServer.Start(iep);
        }
    }
}
