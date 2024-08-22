using System;
using static System.Console;

namespace Game
{
    public class Player
    {
        private static Keyboard[] keyboard = new Keyboard[1];
        
        private byte x;
        private byte y;

        public Player(byte x, byte y)
        {
            Console.WriteLine($"{x}, {y}, {x > Control.Width - 2}, {y > Control.Height - 2}, {y < 0}, {x < 0}");
            if (x > Control.Width - 2 || y > Control.Height - 2 || y < 0 || x < 0)
                throw new ArgumentException();
            
            this.x = x;
            this.y = y;
        }

        public void Move()
        {
            keyboard = Keyboard();

            byte key1 = 0;
            byte key2 = 1;

            if ((keyboard[key1] == Game.Keyboard.Left && keyboard[key2] == Game.Keyboard.Space) || (keyboard[key2] == Game.Keyboard.Left && keyboard[key1] == Game.Keyboard.Space))
            {
                y -= 2;
                x -= 1;
            } else if ((keyboard[key1] == Game.Keyboard.Right && keyboard[key2] == Game.Keyboard.Space) || (keyboard[key2] == Game.Keyboard.Right && keyboard[key1] == Game.Keyboard.Space))
            {
                y -= 2;
                x += 1;
            } else if (keyboard[key1] == Game.Keyboard.Space || keyboard[key2] == Game.Keyboard.Space)
                y -= 2;
            else if (keyboard[key1] == Game.Keyboard.Left || keyboard[key2] == Game.Keyboard.Left)
                x -= 1;
            else if (keyboard[key1] == Game.Keyboard.Right || keyboard[key2] == Game.Keyboard.Right)
                x += 1;
        }

        private Keyboard[] Keyboard()
        {
            Keyboard keyboard1 = Game.Keyboard.Null;
            Keyboard keyboard2 = Game.Keyboard.Null;

            if (KeyAvailable)
            {
                keyboard1 = ConvertToGameKey(ReadKey(true).Key);

                if (KeyAvailable)
                {
                    keyboard2 = ConvertToGameKey(ReadKey(true).Key);
                }
            }

            return new[] { keyboard1, keyboard2 };
        }

        private Keyboard ConvertToGameKey(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.Spacebar => Game.Keyboard.Space,
                ConsoleKey.A => Game.Keyboard.Left,
                ConsoleKey.D => Game.Keyboard.Right,
                _ => Game.Keyboard.Null
            };
        }

        public byte X { get => x; }
        public byte Y { get => y; }
    }
}