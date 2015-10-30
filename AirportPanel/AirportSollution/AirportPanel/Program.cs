using System;
using System.Collections.Generic;
using System.Linq;

namespace AirportPanel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           
            var flightsList = new Flight[1000];
            AddSomeFlight(flightsList);


            var statusDictionary = new Dictionary<FlightStatus, string>
            {
                {FlightStatus.arrived, "Arrived"},
                {FlightStatus.canceled, "Canceled"},
                {FlightStatus.checkIn, "CheckIn"},
                {FlightStatus.delayed, "Delayed"},
                {FlightStatus.departedAt, "Departed at"},
                {FlightStatus.expectedAt, "Expected at"},
                {FlightStatus.gateClosed, "Gate closed"},
                {FlightStatus.inFlight, "In flight"},
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
                if (!int.TryParse(Console.ReadLine(), out command))
                {
                    Console.WriteLine("Please enter correct number of command printed below");
                    continue;
                }
//                var command = Int32.Parse(Console.ReadLine());

                switch ((OperationsEnum) command)
                {
                    case OperationsEnum.ViewAll:
                    {
                        PrintAllFlights(flightsList);
                    }
                        break;
                    case OperationsEnum.ViewArrivals:
                    {
                        PrintArrivalFlights(flightsList);
                    }
                        break;
                    case OperationsEnum.ViewDepartures:
                    {
                        PrintDeparturesFlights(flightsList);
                    }
                        break;
                    case OperationsEnum.Add:
                    {
                        AddFlight(statusDictionary);
                    }
                        break;
                    case OperationsEnum.Edit:
                        break;
                    case OperationsEnum.Delete:
                    {
                        DeleteFlight(flightsList);
                    }
                        break;
                    case OperationsEnum.Info:
                    {
                        GetFlightInfo(flightsList);
                    }                      
                        break;
                    case OperationsEnum.Search:
                    {
                        Console.WriteLine();
                    }

                        break;
                    case OperationsEnum.EmergencyInfo:
                        Console.WriteLine("evacuation");
                        break;
                    case OperationsEnum.Exit:
                        return;
                    default:
                        Console.WriteLine("Please choose number of command printed above");
                        break;
                }
            }
        }

        private static void AddFlight(Dictionary<FlightStatus, string> statusDictionary)
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
            if (!int.TryParse(Console.ReadLine(), out flightNumber))
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
                Console.WriteLine("{0} - {1}", (int) item.Key, item.Value);
            }
            int status;
            if (!int.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Wrong inprut value! Please enter  the current status of the flight");
            }
            else
            {
                var value = "";
                if (!statusDictionary.TryGetValue((FlightStatus) status, out value))
                {
                    Console.WriteLine("Wrong input value! Please enter  the current status of the flight");
                }
            }
            var flight = new Flight
            {
                Airline = airline,
                City = city,
                FlightNumber = flightNumber,
                FlightStatus = (FlightStatus) status,
                Terminal = terminal
            };
        }

        private static void PrintDeparturesFlights(Flight[] FlightsList)
        {
            Console.WriteLine("List of departures flights");
            foreach (
                var flight in
                    FlightsList.Where(x => x.FlightStatus == FlightStatus.departedAt).Select(x => x))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void PrintArrivalFlights(Flight[] FlightsList)
        {
            Console.WriteLine("List of arrivals flights");
            foreach (
                var flight in FlightsList.Where(x => x.FlightStatus == FlightStatus.arrived).Select(x => x))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void PrintAllFlights(Flight[] FlightsList)
        {
            Console.WriteLine("All flights");
            foreach (var flight in FlightsList.OrderBy(x => x.FlightStatus))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void AddSomeFlight(Flight[] FlightsList)
        {
            FlightsList[0] = new Flight
            {
                Airline = "MAU",
                City = "Kharkov",
                FlightNumber = 1001,
                FlightStatus = FlightStatus.delayed,
                Gate = 2,
                Terminal = "A",
                Date = new DateTime(2015, 10, 29, 14, 00, 00)
            };
            FlightsList[1] = new Flight
            {
                Airline = "UA",
                City = "New York",
                FlightNumber = 1002,
                FlightStatus = FlightStatus.arrived,
                Gate = 1,
                Terminal = "D",
                Date = new DateTime(2015, 10, 30, 11, 00, 00)
            };
            FlightsList[2] = new Flight
            {
                Airline = "UA",
                City = "Lviv",
                FlightNumber = 1003,
                FlightStatus = FlightStatus.departedAt,
                Gate = 12,
                Terminal = "C",
                Date = new DateTime(2015, 10, 30, 09, 00, 00)
            };
            FlightsList[3] = new Flight
            {
                Airline = "KLM",
                City = "Berlin",
                FlightNumber = 1004,
                FlightStatus = FlightStatus.canceled,
                Gate = 4,
                Terminal = "F",
                Date = new DateTime(2015, 10, 30, 11, 30, 00)
            };
            FlightsList[4] = new Flight
            {
                Airline = "KLM",
                City = "Amsterdam",
                FlightNumber = 1005,
                FlightStatus = FlightStatus.expectedAt,
                Gate = 5,
                Terminal = "A",
                Date = new DateTime(2015, 10, 30, 11, 30, 00)
            };

            FlightsList[5] = new Flight
            {
                Airline = "KLM",
                City = "Paris",
                FlightNumber = 1006,
                FlightStatus = FlightStatus.gateClosed,
                Gate = 12,
                Terminal = "Z",
                Date = new DateTime(2015, 10, 29, 11, 30, 00)
            };

            FlightsList[6] = new Flight
            {
                Airline = "KLM",
                City = "San Francisco",
                FlightNumber = 1007,
                FlightStatus = FlightStatus.checkIn,
                Gate = 12,
                Terminal = "B",
                Date = new DateTime(2015, 10, 29, 09, 30, 00)
            };
            FlightsList[7] = new Flight
            {
                Airline = "KLM",
                City = "Berlin",
                FlightNumber = 1008,
                FlightStatus = FlightStatus.inFlight,
                Gate = 7,
                Terminal = "C",
                Date = new DateTime(2015, 10, 29, 11, 30, 00)
            };
        }

        private static void GetFlightInfo(Flight[] FlightsList)
        {
            Console.WriteLine("Please enter flight number to get info");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter flight number to get info");
            }
            var item = FlightsList.Where(x => x.FlightNumber == num).Select(x => x).FirstOrDefault();
            Console.WriteLine(item.ToString());
        }

        private static void DeleteFlight(Flight[] FlightsList)
        {
            Console.WriteLine("Please enter flight number to delete");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter flight number to delete");
            }
            var item = FlightsList.Where(x => x.FlightNumber == num).Select(x => x).FirstOrDefault();
            item.FlightStatus = FlightStatus.canceled;
            Console.WriteLine(item.ToString());
        }
    }
}