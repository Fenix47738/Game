using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Game
{
    public class Program
    {
        private static Timer timer;
        private static ManualResetEvent resetEvent= new ManualResetEvent(false);
        
        public static void Main(string[] args)
        {
            SetTimer();
            
            resetEvent.WaitOne();
        }

        private static void SetTimer()
        {
            timer = new Timer(100);
            timer.Elapsed += new ElapsedEventHandler(Control.Playing);
            timer.AutoReset = true;
            timer.Start();
        }
    }
}