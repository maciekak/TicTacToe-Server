﻿using System;
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
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public Game Game { get; set; }

        public bool Moving(int position, string name)
        {
            return true; ////
        }

        public bool TryAdd (string Name, EndPoint EP)
        {
            return true; ///
        }
        public void RemPlayer (string username)
        {

        }
    }

    public enum Result
    {
        
    }
}
