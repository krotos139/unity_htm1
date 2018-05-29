using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            Tests t = new Tests();
            t.HW1();

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
