using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TicTacToe_Server
{
    public class Room
    {
        //public string Name { get; set; }
        private List<Player> _players = new List<Player>();
        public Game game { get; set; }

        //Michal
        //ma przekazac do Game.Moze(position, Field.Player1 lub Field.Player2)
        //ktora zwraca rezultat ostatniego ruchu
        //odsylasz wiadomosc do jednego i drugiego z rezultatem gry
        public bool Moving(int position, string name, Socket server) //server skoro ma wysyłać cośkolwiek
        {
            int index =_players.FindIndex(p => p.Username == name); //OK xDDDDDDDDDD
            Result result = game.Move(position, _players[index]);
            
            return true; // w sumie czemu to jest boolowe?
        }

        //Michał
        //kiedy jest dwoch graczy trzeba stworzyc gre
        public bool TryAdd (string username, EndPoint adress)
        {
            if (_players.Count()==2)
            return false; //
            _players.Add(new Player(username, adress));
            if (_players.Count() == 2)
                game = new Game();
            return true;
        }

        //Michal
        //usuwa gracza, zakancza gre // w sumie niech usunie obu. Po co mu dalej życ? // w sumiee, może od razu wyjebać pokój? W C# Garbage Collector zam wyjebuje obiekty na które nie ma żadnej referencji, a tak wówczas stałoby się z playerami i grą. wyjebywanie jednego obiektu jest cięższe
        public void RemPlayer (string username)
        {
            _players.Remove(_players[0]);
            _players.Remove(_players[1]);

            /*finitialize 
            foreach (Player player in _players)
            {
                delete player;
            }*/

        }
    }

    public enum Result
    {
        Win, Lose, Draw, Nothing //może lepiej Win = WinOfPlayer1, Lose = WinOfPlayer2
    }
}
