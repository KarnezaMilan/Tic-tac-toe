using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Program
    {
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
