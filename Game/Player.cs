using System;
using static System.Console;
using static Game.Config;
using static Game.Control;

namespace Game
{
    public class Player
    {
        private static int x;
        private static int y;
        
        private static Keyboard keyboard = new Keyboard();

        private byte velocity = INITIAL_VELOCITY;
        private byte deltaTime = 1;

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

            if (keyboard == Game.Keyboard.Space)
            {
                WriteAt(' ', x, y);
                
                y -= 5;
                
                WriteAt('P', x, y);
            } else if (keyboard == Game.Keyboard.Left)
            {
                if (Config.MAP[x - 1, y].Equals(Config.WALL))
                    return;
                
                WriteAt(' ', x, y);
                
                x -= 1;
                
                WriteAt('P', x, y);
            }
            else if (keyboard == Game.Keyboard.Right)
            {
                if (Config.MAP[x + 1, y].Equals(Config.WALL))
                    return;
                
                WriteAt(' ', x, y);
                
                x += 1;
                
                WriteAt('P', x, y);
            }
        }
        
        protected internal void PhysicsOfFalling()
        {
            if (y < GROUND_LEVEL)
            {
                velocity +=(byte)(GRAVITY * deltaTime);
                
                WriteAt(' ', x, y);

                y += (byte)(velocity * deltaTime);
                
                WriteAt('P', x, y);

                if (y > GROUND_LEVEL)
                {
                    
                    
                    //Control.GeneratingMap();
                    WriteAt('#', x, y);
                    
                    y = GROUND_LEVEL;
                    velocity = INITIAL_VELOCITY;
                    
                    WriteAt('P', x, y);
                }
            }
        }

        private Keyboard Keyboard()
        {
            Keyboard keyboard = Game.Keyboard.Null;

            if (KeyAvailable)
            {
                keyboard = ConvertToGameKey(ReadKey(true).Key);
            }

            return keyboard;
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

        //protected internal int X { get => x; }
        //protected internal int Y { get => y; }
    }
}