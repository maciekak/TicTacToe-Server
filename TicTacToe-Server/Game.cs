using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Server
{
    public class Game
    {
        public Field[,] Dashboard { get; set; }

        //Maciek
        //Inicjalizuje gre
        public Game()
        {
            Dashboard = new Field[3,3];
        }

        //Maciek
        //Przeprowadza cala gre
        //Zwraca rezultat ostatniego ruchu
        public Result Move(int position, Field player)
        {
            return Result.Nothing; //TODO: temporary
        }

        //if field equals Empty - nobody won, if field is Player1 - first player won, etc
        //Maciek
        //zmienic na bool
        public Field CheckIfSomeoneWon()
        {
            if(CheckIfPlayerWon(Field.Player1))
                return Field.Player1;

            if(CheckIfPlayerWon(Field.Player2))
                return Field.Player2;

            return Field.Empty;
        }

        private bool CheckIfPlayerWon(Field player)
        {
            return Dashboard[0, 0] == player && Dashboard[0, 1] == player && Dashboard[0, 2] == player
                   || Dashboard[1, 0] == player && Dashboard[1, 1] == player && Dashboard[1, 2] == player
                   || Dashboard[2, 0] == player && Dashboard[2, 1] == player && Dashboard[2, 2] == player
                   || Dashboard[0, 0] == player && Dashboard[1, 0] == player && Dashboard[2, 0] == player
                   || Dashboard[0, 1] == player && Dashboard[1, 1] == player && Dashboard[2, 1] == player
                   || Dashboard[0, 2] == player && Dashboard[1, 2] == player && Dashboard[2, 2] == player
                   || Dashboard[0, 0] == player && Dashboard[1, 1] == player && Dashboard[2, 2] == player
                   || Dashboard[2, 0] == player && Dashboard[1, 1] == player && Dashboard[0, 2] == player;
        }
    }

    public enum Field
    {
        Empty, Player1, Player2
    }
}
