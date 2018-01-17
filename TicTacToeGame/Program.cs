using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    class Program
    {
        static bool Zmagovalec(char[,] polje) // Preveri ali je vodoravno / navpično / diagonalno trije x ali o
        {
            if (polje[0, 0] == 'X' && polje[0, 1] == 'X' && polje[0, 2] == 'X' || polje[1, 0] == 'X' && polje[1, 1] == 'X' && polje[1, 2] == 'X' || polje[2, 0] == 'X' && polje[2, 1] == 'X' && polje[2, 2] == 'X' || polje[0, 0] == 'X' && polje[1, 0] == 'X' && polje[2, 0] == 'X' || polje[0, 1] == 'X' && polje[1, 1] == 'X' && polje[2, 1] == 'X' || polje[0, 2] == 'X' && polje[1, 2] == 'X' && polje[2, 2] == 'X' || polje[0, 0] == 'X' && polje[1, 1] == 'X' && polje[2, 2] == 'X' || polje[0, 2] == 'X' && polje[1, 1] == 'X' && polje[2, 0] == 'X' || polje[0, 0] == 'O' && polje[0, 1] == 'O' && polje[0, 2] == 'O' || polje[1, 0] == 'O' && polje[1, 1] == 'O' && polje[1, 2] == 'O' || polje[2, 0] == 'O' && polje[2, 1] == 'O' && polje[2, 2] == 'O' || polje[0, 0] == 'O' && polje[1, 0] == 'O' && polje[2, 0] == 'O' || polje[0, 1] == 'O' && polje[1, 1] == 'O' && polje[2, 1] == 'O' || polje[0, 2] == 'O' && polje[1, 2] == 'O' && polje[2, 2] == 'O' || polje[0, 0] == 'O' && polje[1, 1] == 'O' && polje[2, 2] == 'O' || polje[0, 2] == 'O' && polje[1, 1] == 'O' && polje[2, 0] == 'O')
            {
                return true;
            }
            return false;
        }

        static bool PreveriZasedenost(char[,] polje, int l, int d) // preveri ali je na izbranem mestu že vpisana x ali o ali pa je prazno
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

        static void IgralnaPlosca(char[,] polje) // Izriše koordinatni sistem z vsemi vrednostmi
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

        static int Nakljicni(int Od, int Do) // Določi naključne vrednosti odvisno od pogoja 
        {
            Random rand = new Random();
            return rand.Next(Od, Do);
        }

        static void Main(string[] args)
        {

            char[,] IgralneVrednosti = new char[3, 3]; // Vrednosti X in O v koordinatnem sistemu
            bool Igra = true; // ali trenutno poteka igra 
            char NovaIgra = 'Y'; // ali želite igrati
            string Zahtevnost = null; 

            int x = -1; // koordinate po x osi
            int y = -1; // koordinate po y osi
            int StevecRund = 0; // šteje koliko rund ene igre se je odigralo in kdo je na potezi

            int NaslednjaPoteza = Nakljicni(0, 2); // Naključna izbira kdo bo začel igro ( 0 - računalnik ..... 1 - človek  )
            
            // do while zanka ker se bo vsaj ekrat oddigrala igra.
            do
            {
                Console.WriteLine("Tic-Tuc-toe" + '\n');

                //ponastavitev vrednosti v igralnem polju (izbriše x in o iz polja) 
                //prva zanka skozi x koordinate druga skozi y kooridnate
                for (int i = 0; i < 3; i = i + 1) 
                {
                    for (int j = 0; j < 3; j = j + 1)
                    {
                        IgralneVrednosti[i, j] = '\0';
                    }
                }
                StevecRund = 0; 

                // Zanka se ponavlja doker ni vpisano pravilna vrednos (stopnja zahtevnosti)
                for (bool z = false; z == false; )
                {
                    Console.WriteLine("Izberite zahtevnost:  Lahka     .......   Inteligentna  ");
                    Zahtevnost = Console.ReadLine();//branje zahtevnosti

                    // če je zahtevnost pravilna se zanka konča in program se nadaljuje, drugače zahteva ponovni vpis
                    if (Zahtevnost == "Lahka" || Zahtevnost == "Inteligentna")
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
                        //Če je bila izbrana lahak zahtevnost
                        if (Zahtevnost == "Lahka") 
                        {
                            // z naključno funkcijo izbere x in y koordinato ( med 0 in 2 )
                            x = Nakljicni(0, 3);
                            y = Nakljicni(0, 3);

                            //preveri ali so izbrane kooridnate proste ali zasedene ( drugače bo ponovno izbiral)
                            if (PreveriZasedenost(IgralneVrednosti, x, y) == true) 
                            {
                            }
                            else
                            {
                                IgralneVrednosti[x, y] = 'X'; // v kooridnate vpiše X (računalnik vedno X)
                                IgralnaPlosca(IgralneVrednosti); // kliče funkcijo za izris igralne plošče
                                if (Zmagovalec(IgralneVrednosti) == true) // pregleda ali prišlo do zmagovalca
                                {
                                    Console.WriteLine("Zmagovalec je računalnik!");
                                    break; // Prekine trenutno igro
                                }
                                StevecRund = StevecRund + 1; // Poveča rundo za ena
                                NaslednjaPoteza = 1; // Nastavi človeka za naslednjo potezo.
                            }
                        }
                        else //  INTELIGENTA ZAHTEVNOS 
                        {
                            // kadar gre za 6 rundo ali več  ( pregled kombinacij glede na postavitec x in o po kooridantem sistemu)
                            if (StevecRund >= 6)
                            {
                                // pregleda možne kombinajcije 
                                if (IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[1, 2] == '\0')
                                {
                                    x = 1; y = 2; // nastavitev vrednosti koordinatam
                                    IgralneVrednosti[x, y] = 'X'; // shranitev koordinat
                                    IgralnaPlosca(IgralneVrednosti); // izris igralne plošče 
                                    if (Zmagovalec(IgralneVrednosti) == true) // preverjanje zmagovalca 
                                    {
                                        Console.WriteLine("Zmagovalec je računalnik!");
                                        break;
                                    }
                                    StevecRund = StevecRund + 1; // povečava rund
                                    NaslednjaPoteza = 1; // nastavitev človeka na naslednjo potezo
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else // računalnik bo izbral naključno vrednost
                                {
                                    x = Nakljicni(0, 3);
                                    y = Nakljicni(0, 3);
                                    //preveri 
                                    if (PreveriZasedenost(IgralneVrednosti, x, y) == true) // JE zasedeno, in računalnik bo ponovno izbiral
                                    {
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
                            // 4. runda igre 
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[2, 1] == 'O' && IgralneVrednosti[0, 1] == '\0')
                                {
                                    x = 0; y = 1;
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

                            // 3 ali 5 ali 7 runda
                            if (StevecRund==3 || StevecRund == 5 || StevecRund==7)
                            {
                                if(IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[1, 2] == 'O' && IgralneVrednosti[2, 2] == '\0')
                                {
                                    x = 2; y = 2;
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[2, 2] == 'O' && IgralneVrednosti[2, 1] == 'O' && IgralneVrednosti[2, 0] == '\0')
                                {
                                    x = 2; y = 0;
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
                                else if (IgralneVrednosti[2, 0] == 'O' && IgralneVrednosti[2, 1] == 'O' && IgralneVrednosti[2, 2] == '\0')
                                {
                                    x = 2; y = 2;
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
                                else if (IgralneVrednosti[2, 0] == 'O' && IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[0, 2] == '\0')
                                {
                                    x = 0; y = 2;
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
                                else if (IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[2, 0] == '\0')
                                {
                                    x = 2; y = 0;
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[0, 0] == 'O' && IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[2, 0] == '\0')
                                {
                                    x = 2; y = 0;
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
                                else if (IgralneVrednosti[2, 0] == 'O' && IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[0, 0] == '\0')
                                {
                                    x = 0; y = 0;
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else if (IgralneVrednosti[1, 0] == 'O' && IgralneVrednosti[1, 1] == 'O' && IgralneVrednosti[1, 2] == '\0')
                                {
                                    x = 1; y = 2;
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
                                else if (IgralneVrednosti[0, 0] == 'O' && IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[0, 1] == '\0')
                                {
                                    x = 0; y = 1;
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
                                else if (IgralneVrednosti[0, 2] == 'O' && IgralneVrednosti[2, 2] == 'O' && IgralneVrednosti[1, 2] == '\0')
                                {
                                    x = 1; y = 2;
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
                                else if (IgralneVrednosti[2, 2] == 'O' && IgralneVrednosti[2, 0] == 'O' && IgralneVrednosti[2, 1] == '\0')
                                {
                                    x = 2; y = 1;
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
                                else if (IgralneVrednosti[0, 0] == 'O' && IgralneVrednosti[2, 0] == 'O' && IgralneVrednosti[1, 0] == '\0')
                                {
                                    x = 1; y = 0;
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
                                else
                                {
                                    x = Nakljicni(0, 3);
                                    y = Nakljicni(0, 3);
                                    //preveri 
                                    if (PreveriZasedenost(IgralneVrednosti, x, y) == true) // JE zasedeno, in računalnik bo ponovno izbiral
                                    {
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
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else
                                {
                                    x = 0; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);;
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                            }

                            if (StevecRund == 1)
                            {
                                if (IgralneVrednosti[1, 1] == '\0')
                                {
                                    x = 1; y = 1;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                                else
                                {
                                    x = 0; y = 0;
                                    IgralneVrednosti[x, y] = 'X';
                                    IgralnaPlosca(IgralneVrednosti);
                                    StevecRund = StevecRund + 1;
                                    NaslednjaPoteza = 1;
                                }
                            }
                            // kadar računalnik začne prvi
                            if (StevecRund == 0)
                            {
                                x = 2; y = 0;
                                IgralneVrednosti[x, y] = 'X';
                                IgralnaPlosca(IgralneVrednosti);
                                StevecRund = StevecRund + 1;
                                NaslednjaPoteza = 1;
                            }
                        }
                    }
                    else  // OSEBA
                    {
                        // Vnos koordinat človeka
                        Console.WriteLine("Prosim vnesite koordinate:");
                        Console.Write("x: ");
                        x = int.Parse(Console.ReadLine());
                        Console.Write("y: ");
                        y = int.Parse(Console.ReadLine());

                        // Če so vnešene vrednosti med 0 in 2
                        if (x >= 0 && x < 3 && y >= 0 && y < 3)
                        {
                            bool nekaj = PreveriZasedenost(IgralneVrednosti, x, y); // preveri ali so vnešene koordinate zasedene ali je mesto prosto
                            if (nekaj == true)  // je zasedeno, in oseba bo ponovno izbiral
                            {
                                Console.WriteLine("Polje je že zasedeno");
                            }
                            else
                            {
                                IgralneVrednosti[x, y] = 'O'; // vnos O v koordinate
                                IgralnaPlosca(IgralneVrednosti); // izris igralne plošče
                                if (Zmagovalec(IgralneVrednosti) == true) // preverjanje zmagovalca
                                {
                                    Console.WriteLine("Vi ste zmagovalec!");
                                    break; // končanje igre
                                }
                                StevecRund = StevecRund + 1; // povečava rund 
                                NaslednjaPoteza = 0; // postavitev računalnika za naslednjo runfo
                            }
                        }
                        else
                        {
                            Console.WriteLine("Napačen vpis koordinate, poskusite znova");
                        }
                    }

                    // Preveri ali je bilo oddigranih 9 rund in posledično ni več prostih mest ( neodločen izid )
                    if (StevecRund == 9)
                    {
                        Console.WriteLine("Neodločen izid!");
                        break;
                    }
                }
                // Zanka ki se ponavlja dokler ne dobi pravilnega vnosa
                for (bool zz = false; zz == false; )
                {
                    Console.WriteLine("Želite še eno igro ? Y/N");
                    NovaIgra = char.Parse(Console.ReadLine()); // prebere ali želite novo igro
                    //  če je vnos pravilen ( Y / N ) se zanka zaključi in glede na vnešen vnos se se program nadaljuje ali zaključi
                    if (NovaIgra == 'Y' || NovaIgra == 'N') 
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Napačen vnos!! poskusi znova!!");
                    }
                }
                
            } while (NovaIgra != 'N'); // ALI STE želeli zaključit igro

            Console.ReadKey();
        }
    }
}
