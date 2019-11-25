using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laivanupotus_aliohjelma
{
    class Program
    {
        private static bool AmmuntaToisto(Random KoneenAmmunta, int x, int y, int x2, int y2, int ammusX, int ammusY, int KoneX, int KoneY, int KoneX2, int KoneY2, int koneAmmusX, int koneAmmusY)
        {
            bool osuma1 = false;
            bool osuma2 = false;
            bool KoneOsuma1 = false;
            bool KoneOsuma2 = false;
            bool lopetus = false;

            do // toistetaan ammuntoja siihen asti kunnes pelaaja tai kone osuu kaksi kertaa toisen laivaan
            {
                Console.WriteLine("Tulita koneen laivaa");
                Console.Write("Anna x: "); //Annetaan x-koordinaatti mihin halutaan ampua
                ammusX = int.Parse(Console.ReadLine());

                Console.Write("\nAnna y: "); //Annetaan y-koordinaatti mihin halutaan ampua
                ammusY = int.Parse(Console.ReadLine());

                if (ammusX == KoneX && ammusY == KoneY) // Sait yhden osuman
                {
                    Console.WriteLine("\nOsuma!");
                    Console.WriteLine("------------------------------");
                    osuma1 = true;
                }

                else if (ammusX == KoneX2 && ammusY == KoneY2) // sait yhden osuman
                {
                    Console.WriteLine("\nOsuma!");
                    Console.WriteLine("------------------------------");
                    osuma2 = true;
                }

                else // jos ei tule osumaa niin ohjelmaa ilmoittaa ohi laukauksesta
                {
                    Console.WriteLine("Ammuit ohi");
                    Console.WriteLine("------------------------------");
                }

                if (osuma1 == true && osuma2 == true) // osuit kumpaankin koneen laivan pisteeseen ja voitat pelin
                {
                    Console.WriteLine("\nVoitit Pelin!!!!!");
                    Console.ReadLine();
                    lopetus = true;
                    Environment.Exit(-1);
                }

                // Seuraavaksi tulee koneen vuoro

                Console.WriteLine("Koneen vuoro ampua");

                koneAmmusX = KoneenAmmunta.Next(1, 6);   // kone arpoo x-koordinaatin ampumisen
                koneAmmusY = KoneenAmmunta.Next(1, 6);   // kone arpoo y-koordinaatin ampumisen

                Console.WriteLine("Kone ampui: {0},{1}", koneAmmusX, koneAmmusY);

                if (koneAmmusX == x && koneAmmusY == y) // kone osuu kerran pelaajan laivaan
                {
                    Console.WriteLine("\nKone sai osuman.");
                    Console.WriteLine("------------------------------");
                    KoneOsuma1 = true;
                }

                else if (koneAmmusX == x2 && koneAmmusY == y2) // kone osuu kerran pelaajan laivaan
                {
                    Console.WriteLine("Kone sai osuman.");
                    Console.WriteLine("------------------------------");
                    KoneOsuma2 = true;
                }

                else // jos ei tule osumaa niin ohjelmaa ilmoittaa ohi laukauksesta
                {
                    Console.WriteLine("Kone ampui ohi");
                    Console.WriteLine("------------------------------");
                }

                if (KoneOsuma1 == true && KoneOsuma2 == true) // Kone osuu kumpaankin pelaajan laivan pisteeseen ja häviät pelin
                {
                    Console.WriteLine("\nHävisit pelin!");
                    Console.ReadLine();
                    lopetus = true;
                    Environment.Exit(-1);
                }

            }

            while (lopetus == false);

            return lopetus;
        }

        static void Main(string[] args)
        {

            int x = 0, y = 0, x2 = 0, y2 = 0, KoneX, KoneY, KoneenPidennys, KoneX2 = 0, KoneY2 = 0, ammusX = 0, ammusY = 0, koneAmmusX = 0, koneAmmusY = 0;
            bool Xtarkistus = false;
            bool Ytarkistus = false;
            bool suunta = false;
            bool KoneSuunta = false;
            Random KoneenSijainti = new Random();
            Random KoneenAmmunta = new Random();


            Console.WriteLine("Terve terve tässä on Laivanupotuspeli");
            Console.WriteLine("Pelilaudan koko on 5 x 5");


            Console.WriteLine("\nSijoita laivasi");

            while (Xtarkistus == false)
            {
                Console.Write("\nAnna x: ");  //annetaan x-koordinaatti
                x = int.Parse(Console.ReadLine());

                if (x > 5 || x < 1) //jos yritetään laittaa virheelliseen x-koordinaattiin laivaa ohjelma ilmoittaa siitä ja saat laittaa uuden koordinaatin
                {
                    Console.WriteLine("Piste menee yli pelilaudan, anna uusi X-koordinaatti");
                    Xtarkistus = false;
                }

                Xtarkistus = true;
            }

            while (Ytarkistus == false)
            {
                Console.Write("\nAnna y: "); //annetaan y-koordinaatti
                y = int.Parse(Console.ReadLine());

                if (y > 5 || y < 1) //jos yritetään laittaa virheelliseen y-koordinaattiin laivaa ohjelma ilmoittaa siitä ja saat laittaa uuden koordinaatin
                {
                    Console.WriteLine("Piste menee yli pelilaudan, anna uusi Y-koordinaatti");
                    Ytarkistus = false;
                }

                else
                {
                    Ytarkistus = true;
                }
                
            }

            while (suunta == false)
            {
                Console.WriteLine("\nMihin suuntaan laivaa pidennetään? o = Oikea, v = Vasen, y = Ylös, a= Alas"); //valitaan mihin suuntaan laivaa pidennetään
                String pidennys = Console.ReadLine();

                if (pidennys == "o")
                {
                    x2 = x + 1;
                    y2 = y;
                    suunta = true;
                }

                if (pidennys == "v")
                {
                    x2 = x - 1;
                    y2 = y;
                    suunta = true;
                }

                if (pidennys == "y")
                {
                    x2 = x;
                    y2 = y - 1;
                    suunta = true;
                }

                if (pidennys == "a")
                {
                    x2 = x;
                    y2 = y + 1;
                    suunta = true;
                }

                if (x2 == 0 || x2 == 6 || y2 == 0 || y2 == 6) // katsotaan menikö laivasi pelilaudan ulkopuolelle
                {
                    Console.WriteLine("Laiva meni pelilaudan ulkopuolelle, valitse toinen suunta");
                    suunta = false;
                }
            }

            Console.WriteLine("\nLaivasi on pisteissä: {0}, {1} ja {2}, {3}", x, y, x2, y2); //ohjelma näyttää laivasi sijainnin

            Console.WriteLine("\nKone sijoittaa laivan...");

            KoneX = KoneenSijainti.Next(1, 6);   //kone arpoo x-koordinaatin
            KoneY = KoneenSijainti.Next(1, 6);   //kone arpoo y-koordinaatin

            while (KoneSuunta == false)
            {
                KoneenPidennys = KoneenSijainti.Next(1, 5); //pidentää koneen laivaa johonkin suuntaan

                if (KoneenPidennys == 1)
                {
                    KoneX2 = KoneX + 1;
                    KoneY2 = KoneY;
                    KoneSuunta = true;
                }

                else if (KoneenPidennys == 2)
                {
                    KoneX2 = KoneX - 1;
                    KoneY2 = KoneY;
                    KoneSuunta = true;
                }

                else if (KoneenPidennys == 3)
                {
                    KoneX2 = KoneX;
                    KoneY2 = KoneY + 1;
                    KoneSuunta = true;
                }

                else if (KoneenPidennys == 4)
                {
                    KoneX2 = KoneX;
                    KoneY2 = KoneY - 1;
                    KoneSuunta = true;
                }

                if (KoneX2 == 0 || KoneX2 == 6 || KoneY2 == 0 || KoneY2 == 6) // katsotaan meneekö koneen laiva pelilaudan ulkopuolelle
                {
                    KoneSuunta = false;
                }
            }

            Console.WriteLine("\nKone on sijoittanut laivansa {0}, {1} ja {2}, {3}", KoneX, KoneY, KoneX2, KoneY2);
            Console.WriteLine("------------------------------");

            //Aliohjelma suorittaa ammunnat
            AmmuntaToisto(KoneenAmmunta, x, y, x2, y2, ammusX, ammusY, KoneX, KoneY, KoneX2, KoneY2, koneAmmusX, koneAmmusY);

            Console.ReadLine();

        }
    }
}
