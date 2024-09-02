using System;
using System.Threading;

namespace Game
{
    public class Program
    {
        private static Timer timer;
        
        private static Thread playing = new Thread(new ThreadStart(Control.Playing));
        private static Thread generatingMap = new Thread(new ThreadStart(Control.GeneratingMap));
        
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);
        
        public static void Main(string[] args)
        {
            timer = new Timer(new TimerCallback(TimerTick), null, 0, 100);
            
            resetEvent.WaitOne();
        }

        private static void TimerTick(object state)
        {
            if (!playing.IsAlive || playing == null)
            {
                playing = new Thread(new ThreadStart(Control.Playing));
                playing.IsBackground = true;
                playing.Start();
            }

            if (!generatingMap.IsAlive || generatingMap == null)
            {
                generatingMap = new Thread(new ThreadStart(Control.GeneratingMap));
                generatingMap.IsBackground = true;
                generatingMap.Start();
            }
        }
    }
}