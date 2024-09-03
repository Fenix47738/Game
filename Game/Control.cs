using System;
using System.IO;
using static Game.Config;

namespace Game
{
    public class Control
    {
        private static Player player = new Player((byte)(WIDTH / 2),(byte)(GROUND_LEVEL - 2));

        private static StreamWriter consoleWriter;

        public static void SetStart()
        {
            SetWriter();
        }

        private static void SetWriter()
        {
            consoleWriter = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            
            Console.SetOut(consoleWriter);
        }
        
        public static void Playing()
        {
            player.Move();
            player.PhysicsOfFalling();
        }
    }
}