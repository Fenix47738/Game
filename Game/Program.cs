using System;

namespace Game
{
    public class Program
    {
        private static byte width = 60;
        private static byte height = 24;
        
        public static void Main(string[] args)
        {
            GenerateMap();

            Console.ReadKey();
        }

        private static void GenerateMap()
        {
            for (byte col = 0; col < height; col++)
            {
                for (byte row = 0; row < width; row++)
                {
                    if (row == 0 || col == 0 || row == width - 1 || col == height - 1)
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}