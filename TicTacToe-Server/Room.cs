using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Server
{
    public class Room
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public Game Game { get; set; }

        public bool Moving(int position, string name)
        {
        }
    }

    public enum Result
    {
        
    }
}
