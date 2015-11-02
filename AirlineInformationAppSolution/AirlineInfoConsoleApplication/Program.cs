using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirlineInfoConsoleApplication
{
    class Program
    {
        private static void Main(string[] args)
        {
            var airlineInfo = new AirlineInfo.AirlineInfo();
            while (true)
            {
                Console.WriteLine("Welcome to our airport panel!");
                Console.WriteLine("Please choose number of command printed below");
                Console.WriteLine("0 - View all flights");
                Console.WriteLine("1 - View arrivals");
                Console.WriteLine("2 - View departures");
                Console.WriteLine("3 - Add flight");
                Console.WriteLine("4 - Edit flight");
                Console.WriteLine("5 - Delete flight");
                Console.WriteLine("6 - Flight info");
                Console.WriteLine("7 - Search flight");
                Console.WriteLine("8 - Emergency info ");
                Console.WriteLine("9 - Exit");

            }
        }
    }
}
