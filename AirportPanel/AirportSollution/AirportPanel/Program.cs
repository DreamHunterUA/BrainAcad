using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AirportPanel
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            decimal moneyvalue = 1921.39m;
            string html = String.Format(CultureInfo.CreateSpecificCulture("en-US"), "Order Total: {0:C}", moneyvalue);
            Console.WriteLine(html);





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
                        AddFlight(statusDictionary, flightsList);
                    }
                        break;
                    case OperationsEnum.Edit:
                        EditFlight(statusDictionary, flightsList);
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
                        SearchFlight(statusDictionary, flightsList);
                    }

                        break;
                    case OperationsEnum.EmergencyInfo:
                        Console.WriteLine("Evacuation");
                        break;
                    case OperationsEnum.Exit:
                        return;
                    default:
                        Console.WriteLine("Please choose number of command printed above");
                        break;
                }
                Console.WriteLine("Please enter any key to continue");
                Console.ReadLine();
            }
        }

        private static void SearchFlight(Dictionary<FlightStatus, string> statusDictionary, Flight[] flightsList)
        {
            Console.WriteLine("Please choose number of command printed below");
            Console.WriteLine("0 - Search by flight number");
            Console.WriteLine("1 - Search by date");
            Console.WriteLine("2 - Search by city");
            Console.WriteLine("3 - Search of the flight which is the nearest (1 hour)\n to the specified time");
            Console.WriteLine("4 - Return to main menu");

            int command;
            while (!int.TryParse(Console.ReadLine(), out command))
            {
                Console.WriteLine("Please enter correct number of command printed below");
            }
            switch (command)
            {
                case 0:
                {
                    int flightNumber;

                    Console.WriteLine("Please enter flight number to search");
                    if (!int.TryParse(Console.ReadLine(), out flightNumber))
                    {
                        Console.WriteLine("Wrong input value! Please enter  flight number");
                    }
                    var flight = flightsList.FirstOrDefault(x => x.FlightNumber == flightNumber);
                    Console.WriteLine(flight.ToString());
                }
                    break;

                case 1:
                {
                    Console.WriteLine("Please enter the date and time of the flight.");

                    DateTime dateTime;
                    while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                    {
                        Console.WriteLine(
                            "Please enter correct  date and time of the flight.");
                    }
                    var flights = flightsList.Select(x => x.Date == dateTime);
                    foreach (var flight in flights)
                    {
                        Console.WriteLine(flight.ToString());
                    }
                }
                    break;

                case 2:
                {
                    Console.WriteLine("Please enter city to search");
                    var city = Console.ReadLine();
                    var flights = flightsList.Select(x => x.City == city);
                    foreach (var flight in flights)
                    {
                        Console.WriteLine(flight.ToString());
                    }
                }
                    break;

                case 3:
                {
                    var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        (DateTime.Now.Hour + 1), 0, 0);
                    var flight =
                        flightsList.FirstOrDefault(x =>
                            (x.Date >= DateTime.Now) &
                            (x.Date <= dt));

                    if (flight.FlightStatus == FlightStatus.undefined)
                    {
                        Console.WriteLine("Please enter the date and time of the flight.");

                        DateTime dateTime;
                        while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
                        {
                            Console.WriteLine(
                                "Please enter correct  date and time of the flight.");
                        }

                        var customDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                            (dateTime.Hour + 1), 0, 0);
                        var customFlights =
                            flightsList.Where(x =>
                                (x.Date >= dateTime) &
                                (x.Date <= customDate)).Select(x => x);
                        foreach (var customFlight in customFlights.Where(customFlight => customFlight.FlightStatus != FlightStatus.undefined))
                        {
                            Console.WriteLine(customFlight.ToString());
                        }
                    }
                    else
                        {
                            Console.WriteLine(flight.ToString());
                        }
                }
                    break;

                case 4:
                    return;
                default:
                    return;
                    ;
            }
        }

        private static void EditFlight(Dictionary<FlightStatus, string> statusDictionary, Flight[] flightsList)
        {
            Console.WriteLine("You are going to edit a flight.");
            int flightNumber;

            Console.WriteLine("Please enter flight number");
            if (!int.TryParse(Console.ReadLine(), out flightNumber))
            {
                Console.WriteLine("Wrong input value! Please enter  flight number");
            }
            var flightToUpdate = flightsList.FirstOrDefault(x => x.FlightNumber == flightNumber);
            Console.WriteLine("Below current info about flight");
            Console.WriteLine(flightToUpdate.ToString());


            Console.WriteLine("Please enter new value for airline");
            var airline = Console.ReadLine();
            Console.WriteLine("Please enter new value for city");
            var city = Console.ReadLine();

            Console.WriteLine("Please enter new value for terminal");
            var terminal = Console.ReadLine();

            Console.WriteLine("Please enter new value for  gate");
            int gate;
            while (!int.TryParse(Console.ReadLine(), out gate))
            {
                Console.WriteLine("Wrong input value! Please enter  the gate");
            }


            Console.WriteLine("Please choose the current status of the flight");
            foreach (var item in statusDictionary.OrderBy(x => (int) x.Key))
            {
                Console.WriteLine("{0} - {1}", (int) item.Key, item.Value);
            }
            FlightStatus status;
            while (!Enum.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Wrong input value! Please enter  the current status of the flight");
            }

            Console.WriteLine(
                "Please enter the date and time of the flight.");

            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Please enter correct  date and time of the flight.");
            }
            for (var i = 0; i < flightsList.Length; i++)
            {
                if (flightsList[i].FlightNumber == flightNumber)
                {
                    flightsList[i].FlightStatus = status;
                    flightsList[i].Gate = gate;
                    flightsList[i].Airline = airline;
                    flightsList[i].City = city;
                    flightsList[i].Terminal = terminal;
                    flightsList[i].Date = dateTime;
                    break;
                }
            }
        }

        private static void AddFlight(Dictionary<FlightStatus, string> statusDictionary, Flight[] flightsList)
        {
            Console.WriteLine("You are going to add new flight.");
            int flightNumber;

            Console.WriteLine("Please enter flight number");
            if (!int.TryParse(Console.ReadLine(), out flightNumber))
            {
                Console.WriteLine("Wrong input value! Please enter  flight number");
            }
            Console.WriteLine("Please enter airline");
            var airline = Console.ReadLine();
            Console.WriteLine("Please enter city");
            var city = Console.ReadLine();

            Console.WriteLine("Please enter terminal");
            var terminal = Console.ReadLine();

            Console.WriteLine("Please enter the gate");
            int gate;
            while (!int.TryParse(Console.ReadLine(), out gate))
            {
                Console.WriteLine("Wrong input value! Please enter  the gate");
            }


            Console.WriteLine("Please choose the current status of the flight");
            foreach (var item in statusDictionary.OrderBy(x => (int) x.Key))
            {
                Console.WriteLine("{0} - {1}", (int) item.Key, item.Value);
            }
            FlightStatus status;
            while (!Enum.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Wrong input value! Please enter  the current status of the flight");
            }


            Console.WriteLine(
                "Please enter the date and time of the flight.");

            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine(
                    "Please enter correct  date and time of the flight.");
            }
            var itemToUpdate = flightsList.FirstOrDefault(x => x.FlightStatus == FlightStatus.undefined);
            for (var i = 0; i < flightsList.Length; i++)
            {
                if (flightsList[i].FlightStatus == FlightStatus.undefined)
                {
                    flightsList[i].FlightStatus = status;
                    flightsList[i].FlightNumber = flightNumber;
                    flightsList[i].Gate = gate;
                    flightsList[i].Airline = airline;
                    flightsList[i].City = city;
                    flightsList[i].Terminal = terminal;
                    flightsList[i].Date = dateTime;
                    break;
                }
            }
        }

        private static void PrintDeparturesFlights(IEnumerable<Flight> flightsList)
        {
            Console.WriteLine("List of departures flights");
            foreach (
                var flight in
                    flightsList.Where(x => x.FlightStatus == FlightStatus.departedAt).Select(x => x))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void PrintArrivalFlights(IEnumerable<Flight> flightsList)
        {
            Console.WriteLine("List of arrivals flights");
            foreach (
                var flight in flightsList.Where(x => x.FlightStatus == FlightStatus.arrived).Select(x => x))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void PrintAllFlights(IEnumerable<Flight> flightsList)
        {
            Console.WriteLine("All flights");
            foreach (
                var flight in
                    flightsList.Where(x => x.FlightStatus != FlightStatus.undefined).OrderBy(x => x.FlightStatus))
            {
                Console.WriteLine(flight.ToString());
            }
        }

        private static void AddSomeFlight(Flight[] flightsList)
        {
            flightsList[0] = new Flight
            {
                Airline = "MAU",
                City = "Kharkov",
                FlightNumber = 1001,
                FlightStatus = FlightStatus.delayed,
                Gate = 2,
                Terminal = "A",
                Date = new DateTime(2015, 10, 29, 14, 00, 00)
            };
            flightsList[1] = new Flight
            {
                Airline = "UA",
                City = "New York",
                FlightNumber = 1002,
                FlightStatus = FlightStatus.arrived,
                Gate = 1,
                Terminal = "D",
                Date = new DateTime(2015, 10, 30, 11, 00, 00)
            };
            flightsList[2] = new Flight
            {
                Airline = "UA",
                City = "Lviv",
                FlightNumber = 1003,
                FlightStatus = FlightStatus.departedAt,
                Gate = 12,
                Terminal = "C",
                Date = new DateTime(2015, 10, 30, 09, 00, 00)
            };
            flightsList[3] = new Flight
            {
                Airline = "KLM",
                City = "Berlin",
                FlightNumber = 1004,
                FlightStatus = FlightStatus.canceled,
                Gate = 4,
                Terminal = "F",
                Date = new DateTime(2015, 10, 30, 11, 30, 00)
            };
            flightsList[4] = new Flight
            {
                Airline = "KLM",
                City = "Amsterdam",
                FlightNumber = 1005,
                FlightStatus = FlightStatus.expectedAt,
                Gate = 5,
                Terminal = "A",
                Date = new DateTime(2015, 10, 30, 11, 30, 00)
            };

            flightsList[5] = new Flight
            {
                Airline = "KLM",
                City = "Paris",
                FlightNumber = 1006,
                FlightStatus = FlightStatus.gateClosed,
                Gate = 12,
                Terminal = "Z",
                Date = new DateTime(2015, 10, 29, 11, 30, 00)
            };

            flightsList[6] = new Flight
            {
                Airline = "KLM",
                City = "San Francisco",
                FlightNumber = 1007,
                FlightStatus = FlightStatus.checkIn,
                Gate = 12,
                Terminal = "B",
                Date = new DateTime(2015, 10, 29, 09, 30, 00)
            };
            flightsList[7] = new Flight
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

        private static void GetFlightInfo(IEnumerable<Flight> flightsList)
        {
            Console.WriteLine("Please enter flight number to get info");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter flight number to get info");
            }
            var item = flightsList.FirstOrDefault(x => x.FlightNumber == num);
            Console.WriteLine(item.ToString());
        }

        private static void DeleteFlight(IEnumerable<Flight> flightsList)
        {
            Console.WriteLine("Please enter flight number to delete");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Please enter flight number to delete");
            }
            var item = flightsList.FirstOrDefault(x => x.FlightNumber == num);
            item.FlightStatus = FlightStatus.canceled;
            Console.WriteLine(item.ToString());
        }
    }
}