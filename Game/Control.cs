using System;
using System.Threading;
using static Game.Config;

namespace Game
{
    public class Control
    {
        private static Player player = new Player((byte)(WIDTH / 2),(byte)(GROUND_LEVEL - 2));

        public static void Playing()
        {
            player.Move();
            player.PhysicsOfFalling();
        }

        public static void GeneratingMap()
        {
            Console.Clear();
            
            for (byte col = 0; col < HEIGHT; col++)
            {
                for (byte row = 0; row < WIDTH; row++)
                {
                    if (row == 0 || col == 0 || row == WIDTH - 1 || col == HEIGHT - 1)
                        Console.Write("#");
                    else if (player.X == row && player.Y == col)
                        Console.Write("P");
                    else
                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}