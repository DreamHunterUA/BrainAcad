using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel
{
    internal class Program
    {
        private Flight[] FlightsList = new Flight[]
        {
            new Flight()
            {
                airline = "MAU",
                city = "HRK",
                flightNumber = 1001,
                flightStatus = FlightStatus.delayed,
                gate = "H",
                terminal = 2
            },
            new Flight()
            {
                airline = "UA"
            }, 
        };

        private static void Main(string[] args)
        {
            var result = true;

            while (true)
            {
                Console.WriteLine("Welcome to our airport panel!");
                Console.WriteLine("Please choose number of command printed below");
                Console.WriteLine("1 - View all fligths");
                Console.WriteLine("2 - Add flight");
                Console.WriteLine("3 - Edit flight");
                Console.WriteLine("4 - Delete flight");
                Console.WriteLine("5 - Flight info");
                Console.WriteLine("6 - Search flight");
                Console.WriteLine("7 - Emergency info ");
                Console.WriteLine("8 - Exit");
                var command = int.Parse(Console.ReadLine());

                switch ((OperationsEnum) command)
                {
                    case OperationsEnum.ViewAll:
                        break;
                    case OperationsEnum.Add:
                        break;
                    case OperationsEnum.Edit:
                        break;
                    case OperationsEnum.Delete:
                        break;
                    case OperationsEnum.Info:
                        break;
                    case OperationsEnum.Search:
                        break;
                    case OperationsEnum.EmergencyInfo:
                        break;
                    case OperationsEnum.Exit:
                        return;
                    default:
                        Console.WriteLine("Please choose number of command printed above");
                        break;
                }
            }
        }
    }
}