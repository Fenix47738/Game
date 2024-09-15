using System;
using static System.Console;
using static Game.Config;
using static Game.Control;

namespace Game
{
    public class Player
    {
        private byte velocity = INITIAL_VELOCITY;
        private byte deltaTime = 1;
        
        private static Keyboard[] keyboard = new Keyboard[1];
        
        private static int x;
        private static int y;

        protected internal Player(byte x, byte y)
        {
            if (x > WIDTH - 2 || y > HEIGHT - 2 || y < 0 || x < 0)
                throw new ArgumentException();
            
            Player.x = x;
            Player.y = y;
        }

        protected internal void Move()
        {
            keyboard = Keyboard();

            byte key1 = 0;
            byte key2 = 1;

            if (keyboard[key1] == Game.Keyboard.Space || keyboard[key2] == Game.Keyboard.Space)
            {
                WriteAt(" ", x, y);
                
                y -= 5;
                
                WriteAt("P", x, y);
            } else if (keyboard[key1] == Game.Keyboard.Left || keyboard[key2] == Game.Keyboard.Left)
            {
                if (Config.MAP[x - 1, y].Equals(Config.WALL))
                    return;
                
                WriteAt(" ", x, y);
                
                x -= 1;
                
                WriteAt("P", x, y);
            }
            else if (keyboard[key1] == Game.Keyboard.Right || keyboard[key2] == Game.Keyboard.Right)
            {
                if (Config.MAP[x + 1, y].Equals(Config.WALL))
                    return;
                
                WriteAt(" ", x, y);
                
                x += 1;
                
                WriteAt("P", x, y);
            }
        }
        
        protected internal void PhysicsOfFalling()
        {
            if (y < GROUND_LEVEL)
            {
                velocity +=(byte)(GRAVITY * deltaTime);
                
                WriteAt(" ", x, y);

                y += (byte)(velocity * deltaTime);
                
                WriteAt("P", x, y);

                if (y > GROUND_LEVEL)
                {
                    
                    
                    //Control.GeneratingMap();
                    WriteAt(" ", x, y);
                    
                    y = GROUND_LEVEL;
                    velocity = INITIAL_VELOCITY;
                    
                    WriteAt("P", x, y);
                }
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

        protected internal int X { get => x; }
        protected internal int Y { get => y; }
    }
}