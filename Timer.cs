using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PilotTask2._2
{
    public class Timers
    {
        public static Timer timer;
        public static TimeSpan oneMinute = new TimeSpan(0, 1, 0);
        public static int TimerCursor;
        /// <summary>
        /// Timer function
        /// </summary>
        public static void StartTimer()
        {
            long interval = 1000;

            timer = new Timer(interval);
            //Adds an event to a timer that runs every time the time ends
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            timer.Start();
        }

        /// <summary>
        /// Сountdown and timer output to console
        /// </summary>
        static void TimerElapsed(object obj, ElapsedEventArgs e)
        {
            //Remember the location of the cursor, then to return
            int cursorX = Console.CursorLeft;
            int cursorY = Console.CursorTop;
            Console.SetCursorPosition(60, TimerCursor);
            Console.Write(oneMinute);
            if (oneMinute == new TimeSpan(0, 0, 0))
            {
                Console.SetCursorPosition(60, TimerCursor);
                if (LocalizationHelper.Choise)
                {
                    Console.WriteLine("Время вышло.");
                }
                else
                    Console.WriteLine("Time is over");
                timer.Stop();
            }
            else
                oneMinute = oneMinute.Add(TimeSpan.FromSeconds(-1));
            Console.SetCursorPosition(cursorX, cursorY);
        }
    }
}
