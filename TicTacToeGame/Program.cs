using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Program
    {
        static bool Zmagovalec(char[,] polje)
        {
            if (polje[0, 0] == 'X' && polje[0, 1] == 'X' && polje[0, 2] == 'X' || polje[1, 0] == 'X' && polje[1, 1] == 'X' && polje[1, 2] == 'X' || polje[2, 0] == 'X' && polje[2, 1] == 'X' && polje[2, 2] == 'X' || polje[0, 0] == 'X' && polje[1, 0] == 'X' && polje[2, 0] == 'X' || polje[0, 1] == 'X' && polje[1, 1] == 'X' && polje[2, 1] == 'X' || polje[0, 2] == 'X' && polje[1, 2] == 'X' && polje[2, 2] == 'X' || polje[0, 0] == 'X' && polje[1, 1] == 'X' && polje[2, 2] == 'X' || polje[0, 2] == 'X' && polje[1, 1] == 'X' && polje[2, 0] == 'X' || polje[0, 0] == 'O' && polje[0, 1] == 'O' && polje[0, 2] == 'O' || polje[1, 0] == 'O' && polje[1, 1] == 'O' && polje[1, 2] == 'O' || polje[2, 0] == 'O' && polje[2, 1] == 'O' && polje[2, 2] == 'O' || polje[0, 0] == 'O' && polje[1, 0] == 'O' && polje[2, 0] == 'O' || polje[0, 1] == 'O' && polje[1, 1] == 'O' && polje[2, 1] == 'O' || polje[0, 2] == 'O' && polje[1, 2] == 'O' && polje[2, 2] == 'O' || polje[0, 0] == 'O' && polje[1, 1] == 'O' && polje[2, 2] == 'O' || polje[0, 2] == 'O' && polje[1, 1] == 'O' && polje[2, 0] == 'O')
            {
                return true;
            }


            return false;
        }


        static bool PreveriZasedenost(char[,] polje, int l, int d)
        {
            if (polje[l, d] == '\0')
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        static void IgralnaPlosca(char[,] polje)
        {
            char[,] arr = polje;
            Console.WriteLine();
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0, 0], arr[0, 1], arr[0, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1, 0], arr[1, 1], arr[1, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[2, 0], arr[2, 1], arr[2, 2]);

            Console.WriteLine("     |     |      ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            //git

            char[,] polje = new char[3,3];
            IgralnaPlosca(polje);

            Console.ReadKey();
        }
    }
}
