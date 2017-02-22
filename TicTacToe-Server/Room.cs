using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TicTacToe_Server
{
    public class Room
    {
        //public string Name { get; set; }
        private List<Player> _players = new List<Player>();
        public Game Game { get; set; }

        //Michal
        //ma przekazac do Game.Moze(position, Field.Player1 lub Field.Player2)
        //ktora zwraca rezultat ostatniego ruchu
        //odsylasz wiadomosc do jednego i drugiego z rezultatem gry
        public bool Moving(int position, string name)
        {
            int index =_players.FindIndex(p => p.Username == name);
            return true; ////
        }

        //Michał
        //kiedy jest dwoch graczy trzeba stworzyc gre
        public bool TryAdd (string name, EndPoint ep)
        {
            return true; //
        }

        //Michal
        //usuwa gracza, zakancza gre
        public void RemPlayer (string username)
        {

        }
    }

    public enum Result
    {
        Win, Lose, Draw, Nothing
    }
}
