using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Program
    {/*
        static void Racun(int a, int b)
        {
            char[,] zu = new char[3, 3];
            zu[a, b] = 'X';
            IgralnaPlosca(zu);
        }*/

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

        static int Nakljicni(int Od, int Do)
        {
            Random rand = new Random();
            return rand.Next(Od, Do);
        }

        static void Main(string[] args)
        {

            char[,] IgralneVrednosti = new char[3, 3];

            //IgralnaPlosca(IgralneVrednosti);
            bool Igra = true;
            char NovaIgra = 'Y';

            int x = -1;
            int y = -1;

            int StevecRund = 0;
            //int NovaIgra = -1;


            int NaslednjaPoteza = Nakljicni(0, 2);
            //Console.WriteLine("NAKLJČNO : " + NaslednjaPoteza);


            string Zahtevnost = null;

            do
            {
                Console.WriteLine("Tic-Tuc-toe" + '\n');
                //ponastavitev vrednosti v igralnem polju
                for (int i = 0; i < 3; i = i + 1)
                {
                    for (int j = 0; j < 3; j = j + 1)
                    {
                        IgralneVrednosti[i, j] = '\0';
                    }
                }
                StevecRund = 0;

                for (bool z = false; z == false; )
                {
                    Console.WriteLine("Izberite zahtevnost:  Lahka     .......   Inteligentna  ");
                    Zahtevnost = Console.ReadLine();
                    if (Zahtevnost == "Lahka" || Zahtevnost == "I")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Napačen vnos zahtevnosti!! poskusi znova!!");
                    }
                }


                for (; Igra == true; ) // ena igra
                {

                    if (NaslednjaPoteza == 0)//začne računalnik
                    {
                        if (Zahtevnost == "Lahka")
                        {
                            x = Nakljicni(0, 3);
                            y = Nakljicni(0, 3);
                            //preveri 
                            if (PreveriZasedenost(IgralneVrednosti, x, y) == true) // JE zasedeno, in računalnik bo ponovno izbiral
                            {
                                //NaslednjaPoteza = 0;
                                //Console.WriteLine("Polje je že zasedeno");
                            }
                            else
                            {
                                IgralneVrednosti[x, y] = 'X';
                                IgralnaPlosca(IgralneVrednosti);
                                if (Zmagovalec(IgralneVrednosti) == true)
                                {
                                    Console.WriteLine("Zmagovalec je računalnik!");
                                    break;
                                }
                                StevecRund = StevecRund + 1;
                                NaslednjaPoteza = 1;
                            }

                        }
                        else // inteligentni algoritem**************************************************
                        {

                            if(StevecRund>=6)
                            {
                                if (IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[1, 2] == '\0')
                                {
                                    x =1; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[1, 2] == 'O' && IgralneVrednosti[1, 0] == '\0')
                                {
                                    x = 1; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 0] == 'O' && IgralneVrednosti[0, 1] == 'O' && IgralneVrednosti[0, 2] == '\0')
                                {
                                    x = 0; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 1] == 'O' && IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[0, 0] == '\0')
                                {
                                    x = 0; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[1, 2] == 'O' && IgralneVrednosti[2, 2] == '\0')
                                {
                                    x = 2; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 2] == 'O' && IgralneVrednosti[2, 2] == 'O' && IgralneVrednosti[0, 2] == '\0')
                                {
                                    x = 0; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 1] == 'O' && IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[2, 1] == '\0')
                                {
                                    x = 2; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[2, 1] == 'O' && IgralneVrednosti[0, 1] == '\0')
                                {
                                    x = 0; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else
                                {
                                    x = Nakljicni(0, 3);
                                    y = Nakljicni(0, 3);
                                    //preveri 
                                    if (PreveriZasedenost(IgralneVrednosti, x, y) == true) // JE zasedeno, in računalnik bo ponovno izbiral
                                    {
                                        //NaslednjaPoteza = 0;
                                        //Console.WriteLine("Polje je že zasedeno");
                                    }
                                    else
                                    {
                                        IgralneVrednosti[x, y] = 'X';
                                        IgralnaPlosca(IgralneVrednosti);
                                        if (Zmagovalec(IgralneVrednosti) == true)
                                        {
                                            Console.WriteLine("Zmagovalec je računalnik!");
                                            break;
                                        }
                                        StevecRund = StevecRund + 1;
                                        NaslednjaPoteza = 1;
                                    }
                                }
                            }





                            if (StevecRund == 4)
                            {
                                if (IgralneVrednosti[2, 2] == 'X' && IgralneVrednosti[2, 1] == '\0')
                                {
                                    x = 2; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(2, 1);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 0] == 'X' && IgralneVrednosti[1, 0] == '\0')
                                {
                                    x = 1; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(1, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 1] == '\0')
                                {
                                    x = 1; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(1, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[2, 1] == 'O' && IgralneVrednosti[0,1]=='\0')
                                {
                                    x = 0; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(1, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[1, 2] == '\0')
                                {
                                    x = 1; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    //Racun(1, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else
                                {
                                    x = Nakljicni(0, 3);
                                    y = Nakljicni(0, 3);
                                    //preveri 
                                    if (PreveriZasedenost(IgralneVrednosti, x, y) == true) // JE zasedeno, in računalnik bo ponovno izbiral
                                    {
                                        //NaslednjaPoteza = 0;
                                        //Console.WriteLine("Polje je že zasedeno");
                                    }
                                    else
                                    {
                                        IgralneVrednosti[x, y] = 'X';
                                        IgralnaPlosca(IgralneVrednosti);
                                        if (Zmagovalec(IgralneVrednosti) == true)
                                        {
                                            Console.WriteLine("Zmagovalec je računalnik!");
                                            break;
                                        }
                                        StevecRund = StevecRund + 1;
                                        NaslednjaPoteza = 1;
                                    }
                                }

                            }


                            

                            if (StevecRund == 2)
                            {
                                if (IgralneVrednosti[2, 2] == '\0')
                                {
                                    x = 2; y = 2;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    /*if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }*/
                                    //Racun(2, 2);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;

                                }
                                else
                                {
                                    x = 0; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    /*if (Zmagovalec(IgralneVrednosti) == true)
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }*/
                                    //Racun(0, 0);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                            }

                            

                            if (StevecRund == 0)
                            { 
                                x = 2; y = 0;
                                IgralneVrednosti[x, y] = 'X';
                                IgralnaPlosca(IgralneVrednosti);
                                /*if (Zmagovalec(IgralneVrednosti) == true)
                                {
                                    Console.WriteLine("Zmagovalec je računalnik!");
                                    break;
                                }*/
                                //Racun(2, 0);
                                StevecRund = StevecRund + 1;
                                NaslednjaPoteza = 1;
                            }

                            

                        }

                    }
                    else  // OSEBA
                    {
                        Console.WriteLine("Prosim vnesite koordinate:");
                        Console.Write("x: ");
                        x = int.Parse(Console.ReadLine());
                        Console.Write("y: ");
                        y = int.Parse(Console.ReadLine());


                        if (x >= 0 && x < 3 && y >= 0 && y < 3)
                        {
                            bool nekaj = PreveriZasedenost(IgralneVrednosti, x, y);
                            //Console.WriteLine("NEKAJ: " + nekaj);

                            //preveri ali je zasedeno 
                            if (nekaj == true)  // je zasedeno, in oseba bo ponovno izbiral
                            {
                                //NaslednjaPoteza = 1;
                                Console.WriteLine("Polje je že zasedeno");
                            }
                            else
                            {
                                IgralneVrednosti[x, y] = 'O';
                                IgralnaPlosca(IgralneVrednosti);
                                if (Zmagovalec(IgralneVrednosti) == true)
                                {
                                    Console.WriteLine("Vi ste zmagovalec!");
                                    break;
                                }
                                StevecRund = StevecRund + 1;
                                NaslednjaPoteza = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Napačen vpis koordinate, poskusite znova");
                        }
                    }




                    if (StevecRund == 9)
                    {
                        Console.WriteLine("Neodločen izid!");
                        break;
                    }
                }

                Console.WriteLine("Želite še eno igro ? Y/N");

                NovaIgra = char.Parse(Console.ReadLine());



            } while (NovaIgra != 'N');



            Console.ReadKey();
        }
    }
)
