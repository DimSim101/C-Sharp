using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {

            int numSeconds = 1 * 1000;
            Timer timer = new Timer(numSeconds);

            timer.Elapsed += TimerElapsed;
            timer.Elapsed += TimerElapsed2;

            timer.Start();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hit <Enter> to remove the yellow event or Ctrl-C to exit.");
            Console.ReadLine();
            

            timer.Elapsed -= TimerElapsed2;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hit <Enter> or Ctrl-C to exit.");
            Console.ReadLine();
            
        }

        private static void TimerElapsed(object sender, ElapsedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Time Elapsed: {0:HH:mm:ss.ffff}", args.SignalTime);
        }

        private static void TimerElapsed2(object sender, ElapsedEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Time Elapsed2: {0:HH:mm:ss.ffff}", args.SignalTime);
        }
    }
}
