using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));

            var remoteEP = new IPEndPoint(IPAddress.Any, 0) as EndPoint;

            while (true)
            {
                var data = new byte[1024];

                int receiveLength = server.ReceiveFrom(data, ref remoteEP);
                string message = Encoding.ASCII.GetString(data, 0, receiveLength);

                receiveLength = server.ReceiveFrom(data, ref remoteEP);
                string username = Encoding.ASCII.GetString(data, 0, receiveLength);

                switch (message)
                {
                    case "j":

                        break;

                    case "q":

                        break;

                    case "m":
                        receiveLength = server.ReceiveFrom(data, ref remoteEP);
                        int position = int.Parse(Encoding.ASCII.GetString(data, 0, receiveLength));

                        break;
                }
            }

        }
    }
}
