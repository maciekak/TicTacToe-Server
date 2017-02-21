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
        private Room AddToRoom (List<Room> Rooms, ref string usrname, EndPoint EP)
        {
            foreach (Room r in Rooms)
            {
                if (Room.TryAdd(usrname, EP)) //nie czaje chyba tego błędu :<
                {
                    return r;
                }

            }
            Room extraroom = new Room(); // jakiś sensowny konstrukto by się przydał
            extraroom.TryAdd(usrname, EP);
            return extraroom;
            

        }
        void Main(string[] args) //czemu static? na razie usunąlem.  wtedy wszytskie metody do jakich Main się pośr odwołuje musiałyby być static?
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));

            var remoteEP = new IPEndPoint(IPAddress.Any, 0) as EndPoint; ///Czemu EndPoint a nie IPEndpoint? ma to znacznenie?
            
           // Dictionary<string, EndPoint> users = new Dictionary<string, EndPoint>(); //dict usrname - IP vchyba useless, sorki
            Dictionary<string, Room> users = new Dictionary<string, Room>(); // dict usrname - Room os this usr
            List<Room> Rooms = new List<Room>();

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
                        EndPoint nrIP = remoteEP;
                       // Room room = ;
                        users.Add(username, AddToRoom(Rooms, ref username, nrIP));
                        //users.Add(username, nrIP);
                        


                        break;

                    case "q":

                        users.Remove(username);

                        //Może w ogóle przenieśc Playera do głównego servera, aby był słwnik Player - Room  i do pokoju był wysyłąny gotowy player, do którego móby od razu wysyłąw i ogóle?

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
