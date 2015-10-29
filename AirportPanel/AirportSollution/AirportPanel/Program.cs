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
        private static void Main(string[] args)
        {
            var result = true;
            Flight[] FlightsList =
            {
                new Flight()
                {
                    Airline = "MAU",
                    City = "Kharkov",
                    FlightNumber = 1001,
                    FlightStatus = FlightStatus.delayed,
                    Gate = 2,
                    Terminal = "A",
                    Date = new DateTime(2015, 10, 29, 14, 00, 00)
                },
                new Flight()
                {
                    Airline = "UA",
                    City = "New York",
                    FlightNumber = 1002,
                    FlightStatus = FlightStatus.arrived,
                    Gate = 1,
                    Terminal = "D",
                    Date = new DateTime(2015, 10, 30, 11, 00, 00)
                },
                new Flight()
                {
                    Airline = "UA",
                    City = "Lviv",
                    FlightNumber = 1003,
                    FlightStatus = FlightStatus.departedAt,
                    Gate = 12,
                    Terminal = "C",
                    Date = new DateTime(2015, 10, 30, 09, 00, 00)
                },
                new Flight()
                {
                    Airline = "KLM",
                    City = "Berlin",
                    FlightNumber = 1004,
                    FlightStatus = FlightStatus.canceled,
                    Gate = 4,
                    Terminal = "F",
                    Date = new DateTime(2015, 10, 30, 11, 30, 00)
                },
                new Flight()
                {
                    Airline = "KLM",
                    City = "Amsterdam",
                    FlightNumber = 1005,
                    FlightStatus = FlightStatus.expectedAt,
                    Gate = 5,
                    Terminal = "A",
                    Date = new DateTime(2015, 10, 30, 11, 30, 00)
                }
                ,
                new Flight()
                {
                    Airline = "KLM",
                    City = "Paris",
                    FlightNumber = 1006,
                    FlightStatus = FlightStatus.gateClosed,
                    Gate = 12,
                    Terminal = "Z",
                    Date = new DateTime(2015, 10, 29, 11, 30, 00)
                }
                ,
                new Flight()
                {
                    Airline = "KLM",
                    City = "San Francisco",
                    FlightNumber = 1007,
                    FlightStatus = FlightStatus.checkIn,
                    Gate = 12,
                    Terminal = "B",
                    Date = new DateTime(2015, 10, 29, 09, 30, 00)
                },
                new Flight()
                {
                    Airline = "KLM",
                    City = "Berlin",
                    FlightNumber = 1008,
                    FlightStatus = FlightStatus.inFlight,
                    Gate = 7,
                    Terminal = "C",
                    Date = new DateTime(2015, 10, 29, 11, 30, 00)
                }
            };
            var statusDictionary = new Dictionary<FlightStatus, string>
            {
                {FlightStatus.arrived, "Arrived"},
                {FlightStatus.canceled, "Canceled"},
                {FlightStatus.checkIn, "CheckIn"},
                {FlightStatus.delayed, "Delayed"},
                {FlightStatus.departedAt, "Departed at"},
                {FlightStatus.expectedAt, "Expected at"},
                {FlightStatus.gateClosed, "Gate closed"},
                {FlightStatus.inFlight, "In fligth"},
                {FlightStatus.unknown, "Unknown"}
            };
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
                int command;
                if (!Int32.TryParse(Console.ReadLine(), out command))
                {
                    Console.WriteLine("Please enter correct number of command printed below");
                    continue;
                }
//                var command = Int32.Parse(Console.ReadLine());

                switch ((OperationsEnum) command)
                {
                    case OperationsEnum.ViewAll:
                    {
                        Console.WriteLine("All flights");
                        foreach (var flight in FlightsList.OrderBy(x => x.FlightStatus))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                        break;
                    case OperationsEnum.ViewArrivals:
                    {
                        Console.WriteLine("List of arrivals flights");
                        foreach (
                            var flight in FlightsList.Where(x => x.FlightStatus == FlightStatus.arrived).Select(x => x))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                        break;
                    case OperationsEnum.ViewDepartures:
                    {
                        Console.WriteLine("List of departures flights");
                        foreach (
                            var flight in
                                FlightsList.Where(x => x.FlightStatus == FlightStatus.departedAt).Select(x => x))
                        {
                            Console.WriteLine(flight.ToString());
                        }
                    }
                        break;
                    case OperationsEnum.Add:
                    {
                        Console.WriteLine(
                            "Please enter the date of the flight.\n It must be a string like YYYY/MM/DD HH/MM/SS");
                        var dateOfFlight = Console.ReadLine();


                        DateTime dateTime;
                        if (DateTime.TryParse(dateOfFlight, out dateTime))
                        {
                            Console.WriteLine(dateTime);
                        }


                        Console.WriteLine("You are going to add new flight.");
                        int flightNumber;

                        Console.WriteLine("Please enter flight number");
                        if (!Int32.TryParse(Console.ReadLine(), out flightNumber))
                        {
                            Console.WriteLine("Wrong inprut value! Please enter  flight number");
                        }
                        Console.WriteLine("Please enter airline");
                        var airline = Console.ReadLine();
                        Console.WriteLine("Please enter city");
                        var city = Console.ReadLine();

                        Console.WriteLine("Please enter terminal");
                        var terminal = Console.ReadLine();
                        Console.WriteLine("Please choose the current status of the flight");
                        foreach (var item in statusDictionary.OrderBy(x => (int) x.Key))
                        {
                            Console.WriteLine(String.Format("{0} - {1}", (int) item.Key, item.Value));
                        }
                        int status;
                        if (!Int32.TryParse(Console.ReadLine(), out status))
                        {
                            Console.WriteLine("Wrong inprut value! Please enter  the current status of the flight");
                        }
                        else
                        {
                            string value = "";
                            if (!statusDictionary.TryGetValue((FlightStatus) status, out value))
                            {
                                Console.WriteLine("Wrong inprut value! Please enter  the current status of the flight");
                            }
                        }
                        
                    }
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