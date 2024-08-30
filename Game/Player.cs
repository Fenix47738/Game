using System;
using static System.Console;
using static Game.Config;

namespace Game
{
    public class Player
    {
        private byte velocity = INITIAL_VELOCITY;
        private byte deltaTime = 1;
        
        private static Keyboard[] keyboard = new Keyboard[1];
        
        private byte x;
        private byte y;

        public Player(byte x, byte y)
        {
            if (x > WIDTH - 2 || y > HEIGHT - 2 || y < 0 || x < 0)
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
                y -= 5;
                x -= 1;
            } else if ((keyboard[key1] == Game.Keyboard.Right && keyboard[key2] == Game.Keyboard.Space) || (keyboard[key2] == Game.Keyboard.Right && keyboard[key1] == Game.Keyboard.Space))
            {
                y -= 5;
                x += 1;
            } else if (keyboard[key1] == Game.Keyboard.Space || keyboard[key2] == Game.Keyboard.Space)
                y -= 5;
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

        public void PhysicsOfFalling()
        {
            Console.WriteLine(y < GROUND_LEVEL);
            if (y < GROUND_LEVEL)
            {
                velocity +=(byte)(GRAVITY * deltaTime);

                y += (byte)(velocity * deltaTime); //(byte)Math.Round(velocity * deltaTime);

                if (y > GROUND_LEVEL)
                {
                    y = GROUND_LEVEL;
                    velocity = INITIAL_VELOCITY;
                }
            }
        }

        public byte X { get => x; }
        public byte Y { get => y; }
    }
}