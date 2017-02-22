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
        private static Room AddToRoom (List<Room> rooms, string usrname, EndPoint EP)
        {
            foreach (Room room in rooms)
            {
                
                if (room.TryAdd(usrname, EP))
                {
                    return room;
                }

            }
            Room extraroom = new Room(); // jakiś sensowny konstrukto by się przydał
            extraroom.TryAdd(usrname, EP);
            return extraroom;
            

        }
        static void Main(string[] args)
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1024));

            var remoteEP = new IPEndPoint(IPAddress.Any, 0) as EndPoint;
            
           // Dictionary<string, EndPoint> users = new Dictionary<string, EndPoint>(); //dict usrname - IP vchyba useless, sorki
            Dictionary<string, Room> users = new Dictionary<string, Room>(); // dict usrname - Room os this usr
            List<Room> Rooms = new List<Room>();

            while (true)
            {
                var data = new byte[1024];

                int receiveLength = server.ReceiveFrom(data, ref remoteEP);
                string message = Encoding.ASCII.GetString(data, 0, receiveLength);
                TypeOfMessage typeOfMessage;
                if(!Enum.TryParse(message, out typeOfMessage))
                {
                    Console.WriteLine("Uncorrect message from client.\nLet's try again");
                    continue;
                }

                receiveLength = server.ReceiveFrom(data, ref remoteEP);
                string username = Encoding.ASCII.GetString(data, 0, receiveLength);

                switch (typeOfMessage)
                {
                    case TypeOfMessage.Join:
                        EndPoint nrIP = remoteEP;
                       // Room room = ;
                        users.Add(username, AddToRoom(Rooms, username, nrIP)); //vide 30
                        //users.Add(username, nrIP);
                        Console.WriteLine("Added user " + username + " from: " + remoteEP.ToString());
                        


                        break;

                    case TypeOfMessage.Quit:

                        //usunięcie z pokoju
                        users[username].RemPlayer(username);

                        users.Remove(username);
                        // i jeszcze usunięcie ze słownika
                        Console.WriteLine("Removed user " + username + " from: " + remoteEP.ToString());

                        //Może w ogóle przenieśc Playera do głównego servera, aby był słwnik Player - Room  i do pokoju był wysyłąny gotowy player, do którego móby od razu wysyłąw i ogóle?
                        // .... hm, a może nie
                        break;


                    case TypeOfMessage.Move: 
                        receiveLength = server.ReceiveFrom(data, ref remoteEP);
                        int position = int.Parse(Encoding.ASCII.GetString(data, 0, receiveLength));
                        users[username].Moving(position, username);
                        Console.WriteLine("User " + username + " made a move: " + position.ToString());


                        break;
                }
            }

        }
    }

    public enum TypeOfMessage
    {
        Join, Quit, Move
    }
}
