using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            int[] elf = new int[db];
            int[] player = new int[db];
            int i = 0;
            while (i < db)
            {
                var d = rounds[i].Split();
                switch (d[0])
                {
                    case "A": elf[i] = 1; break;
                    case "B": elf[i] = 2; break;
                    case "C": elf[i] = 3; break;

                    default:
                        break;
                }
                switch (d[1])
                {
                    case "X": player[i] = 1; break;
                    case "Y": player[i] = 2; break;
                    case "Z": player[i] = 3; break;

                    default:
                        break;
                }
                Console.WriteLine(elf[i] + " " + player[i]);



                i++;
            }
            reader.Close();



            Console.WriteLine();


            int elfpoints = 0;
            int playerpoints = 0;
            for (int t = 0; t < db; t++)
            {
                if (elf[t] > player[t] && (elf[t] - player[t] != 2))
                {
                    elfpoints += elf[t] + 6;
                    playerpoints += player[t];
                }
                else if (elf[t] > player[t] && (elf[t] - player[t] == 2))
                {
                    playerpoints += player[t] + 6;
                    elfpoints += elf[t];
                }
                else if (player[t] > elf[t] && (player[t] - elf[t] != 2))
                {
                    playerpoints += player[t] + 6;
                    elfpoints += elf[t];
                }
                else if (player[t] > elf[t] && (player[t] - elf[t] == 2))
                {
                    elfpoints += elf[t] + 6;
                    playerpoints += player[t];
                }
                else if (elf[t] == player[t])
                {
                    playerpoints += player[t] + 3;
                    elfpoints += elf[t] + 3;
                }


            }
            //Console.WriteLine(player.Sum());
            Console.WriteLine("Points of the elf: " + elfpoints);
            Console.WriteLine("Points of the player: " + playerpoints);

            Console.WriteLine("Rigth answer: 14069");

        }
    }
}
