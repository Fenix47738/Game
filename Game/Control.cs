using System;
using System.Timers;

namespace Game
{
    public class Control
    {
        private static byte width = 60;
        private static byte height = 24;
        
        private static Player player = new Player((byte)(width / 2),(byte)(height - 2));

        public static void Playing(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            player.Move();
            
            GeneratingMap();
        }

        private static void GeneratingMap()
        {
            Console.Clear();
            
            for (byte col = 0; col < height; col++)
            {
                for (byte row = 0; row < width; row++)
                {
                    if (row == 0 || col == 0 || row == width - 1 || col == height - 1)
                        Console.Write("#");
                    else if (player.X == row && player.Y == col)
                        Console.Write("P");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
        
        public static byte Width { get => width; }
        public static byte Height { get => height; }
    }
}