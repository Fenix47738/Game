﻿using System;
using System.Threading;

namespace Game
{
    public class Program
    {
        private static Timer timer;
        
        private static Thread playing = new Thread(new ThreadStart(Control.Playing));
        
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);
        
        public static void Main(string[] args)
        {
            Control.SetStart();
            
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
        }
    }
}