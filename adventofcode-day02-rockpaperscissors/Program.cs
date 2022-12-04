using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;

namespace adventofcode_02_rockpaperscissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open file for reading
            StreamReader sorszam = new StreamReader("strategyguide.txt");
            int db = 0;
            while (sorszam.ReadLine() != null)
            {

                db++;
            }
            Console.WriteLine("Sorok szama: " + db);
            sorszam.Close();
            StreamReader reader = new StreamReader("strategyguide.txt");

            string input = reader.ReadToEnd();
            string[] rounds = input.Split('\n');

            List<string> left = new List<string>();
            List<string> right = new List<string>();

            string[] elfstring = new string[db];
            string[] playerstring = new string[db];

            int[] elf = new int[db];
            int[] player = new int[db];
            int i = 0;
            while (i < db)
            {
                var d = rounds[i].Split();
                switch (d[0])
                {
                    case "A": elf[i] = 1; elfstring[i] = "A"; break;
                    case "B": elf[i] = 2; elfstring[i] = "B"; break;
                    case "C": elf[i] = 3; elfstring[i] = "C"; break;

                    default:
                        break;
                }
                switch (d[1])
                {
                    case "X": player[i] = 1; playerstring[i] = "X"; break;
                    case "Y": player[i] = 2; playerstring[i] = "Y"; break;
                    case "Z": player[i] = 3; playerstring[i] = "Z"; break;

                    default:
                        break;
                }




                i++;
            }
            reader.Close();



            Console.WriteLine();

            // ************- THE FIRST ROUND: -************
            int elfpoints = 0;
            int playerpoints = 0;
            for (int t = 0; t < db; t++)
            {
                if (elf[t] > player[t] && (elf[t] - player[t] != 2))
                {
                    Console.WriteLine(elfstring[t] + " " + playerstring[t] + " => " + elf[t] + " - " + player[t] + " \tELF WON! ");
                    elfpoints += elf[t] + 6;
                    playerpoints += player[t];
                }
                else if (elf[t] > player[t] && (elf[t] - player[t] == 2))
                {
                    Console.WriteLine(elfstring[t] + " " + playerstring[t] + " => " + elf[t] + " - " + player[t] + " \tPLAYER WON! ");
                    playerpoints += player[t] + 6;
                    elfpoints += elf[t];
                }
                else if (player[t] > elf[t] && (player[t] - elf[t] != 2))
                {
                    Console.WriteLine(elfstring[t] + " " + playerstring[t] + " => " + elf[t] + " - " + player[t] + " \tPLAYER WON! ");
                    playerpoints += player[t] + 6;
                    elfpoints += elf[t];
                }
                else if (player[t] > elf[t] && (player[t] - elf[t] == 2))
                {
                    Console.WriteLine(elfstring[t] + " " + playerstring[t] + " => " + elf[t] + " - " + player[t] + " \tELF WON! ");
                    elfpoints += elf[t] + 6;
                    playerpoints += player[t];
                }
                else if (elf[t] == player[t])
                {
                    Console.WriteLine(elfstring[t] + " " + playerstring[t] + " => " + elf[t] + " - " + player[t] + " \tDRAW! ");
                    playerpoints += player[t] + 3;
                    elfpoints += elf[t] + 3;
                }
            }

            // ************- THE SECOND ROUND: -************
            int secElfpoints = 0;
            int secPlayerpoints = 0;
            for (int s = 0; s < db; s++)
            {
                if (playerstring[s] == "Y")
                {
                    if (elfstring[s] == "A")
                    {
                        secElfpoints += 1 + 3;
                        secPlayerpoints += 1 + 3;
                    }
                    else if (elfstring[s] == "B")
                    {
                        secElfpoints += 2 + 3;
                        secPlayerpoints += 2 + 3;
                    }
                    else if (elfstring[s] == "C")
                    {
                        secElfpoints += 3 + 3;
                        secPlayerpoints += 3 + 3;
                    }
                }
                else if (playerstring[s] == "X")
                {
                    if (elfstring[s] == "A")
                    {
                        secElfpoints += 1 + 6;
                        secPlayerpoints += 3;
                    }
                    else if (elfstring[s] == "B")
                    {
                        secElfpoints += 2 + 6;
                        secPlayerpoints += 1;
                    }
                    else if (elfstring[s] == "C")
                    {
                        secElfpoints += 3 + 6;
                        secPlayerpoints += 2;
                    }
                }
                else if (playerstring[s] == "Z")
                {
                    if (elfstring[s] == "A")
                    {
                        secElfpoints += 1;
                        secPlayerpoints += 2 + 6;
                    }
                    else if (elfstring[s] == "B")
                    {
                        secElfpoints += 2;
                        secPlayerpoints += 3 + 6;
                    }
                    else if (elfstring[s] == "C")
                    {
                        secElfpoints += 3;
                        secPlayerpoints += 1 + 6;
                    }
                }
            }

            //Console.WriteLine(player.Sum());
            Console.WriteLine("Points of the Elf in the first round: " + elfpoints);
            Console.WriteLine("Points of the Player in the first round: " + playerpoints);
            Console.WriteLine("The right answer is: 14069");

            Console.WriteLine();

            Console.WriteLine("Points of the Elf in the second round: " + secElfpoints);
            Console.WriteLine("Points of the Player in the second round: " + secPlayerpoints);
            Console.WriteLine("The right answer is: 12411");
        }
    }
}
