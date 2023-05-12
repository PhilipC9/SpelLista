using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpelLista
{
    class Program
    {
        static void Main(string[] args)
        {
            string ascii = @"
░██████╗██████╗░███████╗██╗░░░░░ ██╗░░░░░██╗░██████╗████████╗░█████╗░
██╔════╝██╔══██╗██╔════╝██║░░░░░ ██║░░░░░██║██╔════╝╚══██╔══╝██╔══██╗
╚█████╗░██████╔╝█████╗░░██║░░░░░ ██║░░░░░██║╚█████╗░░░░██║░░░███████║
░╚═══██╗██╔═══╝░██╔══╝░░██║░░░░░ ██║░░░░░██║░╚═══██╗░░░██║░░░██╔══██║
██████╔╝██║░░░░░███████╗███████╗ ███████╗██║██████╔╝░░░██║░░░██║░░██║
╚═════╝░╚═╝░░░░░╚══════╝╚══════╝ ╚══════╝╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝";

            int alternativ = 0;
            double totalSpeltid = 0;
            List<MusikData> musikData = new List<MusikData>();

            while (true)
            {
                while (true)
                {
                    try
                    {
                        // Meny
                        Console.Clear();
                        Console.WriteLine(ascii);
                        Console.WriteLine();
                        Console.WriteLine("1. Lägg till en ny låt");
                        Console.WriteLine("2. Redigera speltiden på en låt");
                        Console.WriteLine("3. Ta bort en låt från spellistan");
                        Console.WriteLine("4. Visa spellista");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("5. Avsluta");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.Write("Inmatning>: ");
                        alternativ = int.Parse(Console.ReadLine());
                        break;
                    }

                    //Felhantering
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Fel inmatning!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Tryck Enter för att fortsätta...");
                        Console.ReadLine();
                    }
                }

                switch (alternativ)
                {
                    // Case1: Lägger till en ny låt
                    case 1:
                        while (true)
                        {
                            try
                            {
                                // Frågar användaren efter inmatningar för låten
                                Console.Clear();
                                Console.WriteLine("| Lägg till en ny låt |");
                                Console.WriteLine();

                                Console.WriteLine("_____Titel_____");
                                Console.Write(">: ");
                                string titel = Console.ReadLine();
                                Console.WriteLine();

                                Console.WriteLine("_____Genre_____");
                                Console.Write(">: ");
                                string genre = Console.ReadLine();
                                Console.WriteLine();

                                Console.WriteLine("_____Artist_____");
                                Console.Write(">: ");
                                string artist = Console.ReadLine();
                                Console.WriteLine();

                                Console.WriteLine("_____Speltid_____");
                                Console.Write(">: ");
                                double speltid = Math.Round(double.Parse(Console.ReadLine()), 2);
                                totalSpeltid += speltid;
                                Console.WriteLine();

                                // Skapar en låt i listan efter användarens inmatningar ovan.
                                musikData.Add(new MusikData(titel, genre, artist, speltid));
                                    
                                // Väntar på enter
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Låten {0} har lagts till i spellistan!", titel);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Tryck Enter för att fortsätta...");
                                Console.ReadLine();
                                break;
                            }
                            //Felhantering
                            catch
                            {
                                Console.WriteLine("Fel inmatning, försök igen");
                            }
                        }
                        break;

                        // Case 2: Redigera speltiden
                    case 2:
                        while (true)
                        {
                            try
                            {
                                // Skriver ut alla låtar
                                Console.Clear();
                                Console.WriteLine("| Redigera speltiden på en låt |");
                                Console.WriteLine();
                                for (int i = 0; i < musikData.Count; i++)
                                {
                                    Console.WriteLine("_______________________________________________________________________________\n");
                                    Console.Write("{0}. ", i + 1);
                                    musikData[i].visaLåtar();
                                    Console.WriteLine("_______________________________________________________________________________");
                                }
                                Console.WriteLine();

                                // Frågar användare efter låt
                                Console.WriteLine("Ange spårnummer för den låten som du vill ändra.");
                                Console.Write("Spårnummer>: ");
                                int angivet = int.Parse(Console.ReadLine())-1;
                                Console.Write("Ny tid >:");

                                // Ändrar tiden på den valda låten från listan
                                musikData[angivet].redigeraSpeltid(int.Parse(Console.ReadLine()));
                                Console.WriteLine("Låtens speltid har ändrats!");

                                // Väntar på Enter
                                Console.WriteLine();
                                Console.WriteLine("Tryck Enter för att fortsätta...");
                                Console.ReadLine();

                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Ett fel uppstod, ange ett spårnummer från listan.");
                            }
                        }
                        break;


                        // Case 3: Ta bort en låt
                    case 3:

                        while (true)
                        {
                            try 
                            { 
                         
                        //Skriver ut alla låtar
                        Console.Clear();
                        Console.WriteLine("| Ta bort en låt |");
                        Console.WriteLine();
                        for (int i = 0; i < musikData.Count; i++)
                        {
                            Console.WriteLine("_______________________________________________________________________________\n");
                            Console.Write("{0}. ", i + 1);
                            musikData[i].visaLåtar();
                            Console.WriteLine("_______________________________________________________________________________");
                        }
                                Console.WriteLine();

                                // Frågar användare efter låt
                                Console.WriteLine("Ange spårnummer för den låten som du vill ta bort.");
                                Console.Write("Spårnummer >: ");
                                int radera = int.Parse(Console.ReadLine())-1;

                                // Tar bort den angivna låten från listan
                                musikData.RemoveAt(radera);
                                Console.WriteLine("Låten är borttagen!");

                                // Väntar på Enter
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Tryck Enter för att fortsätta...");
                                Console.ReadLine();

                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Ett fel uppstod, ange ett spårnummer från listan.");
                            }
                        }
                        break;


                        // Case 4: Visa spellistan
                    case 4:

                        // Skriver ut alla låtar
                        Console.Clear();
                        Console.WriteLine("| Spellista |");
                        Console.WriteLine();
                        for(int i = 0; i < musikData.Count; i++)
                        {
                            Console.WriteLine("_______________________________________________________________________________\n");
                            Console.Write("{0}. ", i + 1);
                            musikData[i].visaLåtar();
                            Console.WriteLine("_______________________________________________________________________________");
                        }
                        Console.WriteLine();

                        // Skriver ut den totala speltiden
                        Console.WriteLine("Total Speltid: {0}min", totalSpeltid);
                        Console.ReadLine();
                        break;

                        // Case 5: Avslutar programmet
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
