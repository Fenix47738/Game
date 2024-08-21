using System;
using System.Timers;

namespace Game
{
    public class Program
    {
        private static Timer timer;
        
        public static void Main(string[] args)
        {
            SetTimer();
            
            Console.ReadKey();
            
            timer.Stop();
            timer.Dispose();
        }

        private static void SetTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(Control.GeneratingMap);
            timer.AutoReset = true;
            timer.Start();
        }
    }
}