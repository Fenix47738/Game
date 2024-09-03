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
        
        private static int x;
        private static int y;

        public Player(byte x, byte y)
        {
            if (x > WIDTH - 2 || y > HEIGHT - 2 || y < 0 || x < 0)
                throw new ArgumentException();
            
            Player.x = x;
            Player.y = y;
        }

        public void Move()
        {
            keyboard = Keyboard();

            byte key1 = 0;
            byte key2 = 1;

            if (keyboard[key1] == Game.Keyboard.Space || keyboard[key2] == Game.Keyboard.Space)
            {
                Draw(" ");
                
                y -= 5;
                
                Draw("P");
            } else if (keyboard[key1] == Game.Keyboard.Left || keyboard[key2] == Game.Keyboard.Left)
            {
                Draw(" ");
                
                x -= 1;
                
                Draw("P");
            }
            else if (keyboard[key1] == Game.Keyboard.Right || keyboard[key2] == Game.Keyboard.Right)
            {
                Draw(" ");
                
                x += 1;
                
                Draw("P");
            }
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

        private void Draw(string s)
        {
            SetCursorPosition(x, y);
            Write(s);
        }

        public void PhysicsOfFalling()
        {
            if (y < GROUND_LEVEL)
            {
                velocity +=(byte)(GRAVITY * deltaTime);
                
                Draw(" ");

                y += (byte)(velocity * deltaTime);
                
                Draw("P");

                if (y > GROUND_LEVEL)
                {
                    
                    
                    //Control.GeneratingMap();
                    Draw(" ");
                    
                    y = GROUND_LEVEL;
                    velocity = INITIAL_VELOCITY;
                    
                    Draw("P");
                }
            }
        }

        public int X { get => x; }
        public int Y { get => y; }
    }
}