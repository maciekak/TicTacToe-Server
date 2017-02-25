using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            
            //Array initializing
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    Dashboard[x, y] = Field.Empty;
        }

        //Maciek
        //Przeprowadza cala gre
        //Zwraca rezultat ostatniego ruchu
        public Result Move(int position, Player player) //przekażmy może lepiej całego playera bo by trzeba enuma kopiować //ale wtedy nie wiem ktory player jest pierwszy
        {
            var field = Field.Player1; //TODO: temporary
            Dashboard[position%3, position/3] = field;

            if(CheckIfPlayerWon())
                return Result.Win;

            if(CheckIfIsAnyEmptyField())
                return Result.Nothing;

            return Result.Draw;
        }

        //Maciek
        private bool CheckIfPlayerWon()
        {
            return Dashboard[0, 0] == Dashboard[0, 1] && Dashboard[0, 1] == Dashboard[0, 2] && Dashboard[0, 0] != Field.Empty
                   || Dashboard[1, 0] == Dashboard[1, 1] && Dashboard[1, 1] == Dashboard[1, 2] && Dashboard[1, 0] != Field.Empty
                   || Dashboard[2, 0] == Dashboard[2, 1] && Dashboard[2, 1] == Dashboard[2, 2] && Dashboard[2, 0] != Field.Empty
                   || Dashboard[0, 0] == Dashboard[1, 0] && Dashboard[1, 0] == Dashboard[2, 0] && Dashboard[0, 0] != Field.Empty
                   || Dashboard[0, 1] == Dashboard[1, 1] && Dashboard[1, 1] == Dashboard[2, 1] && Dashboard[0, 1] != Field.Empty
                   || Dashboard[0, 2] == Dashboard[0, 1] && Dashboard[1, 2] == Dashboard[2, 2] && Dashboard[0, 2] != Field.Empty
                   || Dashboard[0, 0] == Dashboard[1, 1] && Dashboard[1, 1] == Dashboard[2, 2] && Dashboard[0, 0] != Field.Empty
                   || Dashboard[2, 0] == Dashboard[1, 1] && Dashboard[1, 1] == Dashboard[0, 2] && Dashboard[2, 0] != Field.Empty;
        }

        private bool CheckIfIsAnyEmptyField()
        {
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (Dashboard[x, y] == Field.Empty)
                        return true;
            return false;
        }
    }

    public enum Field
    {
        Empty, Player1, Player2
    }
}
