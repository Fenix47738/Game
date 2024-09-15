using System;
using System.IO;
using static Game.Config;

namespace Game
{
    public class Control
    {
        private static Player player = new Player((byte)(WIDTH / 2),(byte)(GROUND_LEVEL - 2));

        private static StreamWriter consoleWriter;

        protected internal static void SetStart()
        {
            for (int row = 0; row < MAP.GetLength(0); row++)
            {
                for (int col = 0; col < MAP.GetLength(1); col++)
                {
                    Console.Write(MAP[row, col]);
                }
                
                Console.WriteLine();
            }
            
            SetWriter();
        }

        private static void SetWriter()
        {
            consoleWriter = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            
            Console.SetOut(consoleWriter);
        }
        
        protected internal static void Playing()
        {
            player.Move();
            player.PhysicsOfFalling();
        }

        protected internal static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.Clear();
                Console.WriteLine("Error");
                Console.ReadKey();

                throw e;
            }
        }
    }
}