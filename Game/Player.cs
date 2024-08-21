using System;

namespace Game
{
    public class Player
    {
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

        public byte X { get => x; }
        public byte Y { get => y; }
    }
}