using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AirlineInfo
{
    public class AirlineInfo
    {
        private List<Fligth> _flightList;
  

        public AirlineInfo()
        {
            _flightList = new List<Fligth>();
           
        }

        public List<Fligth> FlightList
        {
            get { return _flightList; }
            set { _flightList = value; }
        }

        

        public void AddFlight(Fligth fligth)
        {
            FlightList.Add(fligth);
        }

        public void DeleteFlight(int number)
        {
            var itemToDelete = _flightList.First(x => x.FlightNumber == number);
            FlightList.Remove(itemToDelete);
        }

        public List<Fligth> GetArrivalsFligths()
        {
            return (List < Fligth > )_flightList.Select(x => x.Status == FlightStatus.arrived);
        }
        public List<Fligth> GetDeparturesFligths()
        {
            return (List<Fligth>)_flightList.Select(x => x.Status == FlightStatus.departedAt);
        }
        public Fligth GetFlightInfo(int number)
        {
            return _flightList.First(x => x.FlightNumber == number);
        }

        public Fligth SearchByNumber(int number)
        {
            return _flightList.First(x => x.FlightNumber == number);
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public List<Fligth> SearchByPrice(decimal price)
        {
            return _flightList.Where(x => (x.EconomyClassPrice == price || x.BusinessClassPrice == price)).ToList();
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public List<Fligth> SearchByPassengerFirstName(string firstName)
        {
            return _flightList.Where(x => x.PassengerList.Exists(y => y.FirstName == firstName)).ToList();
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public List<Fligth> SearchByPassengerLastName(string lastName)
        {
            return _flightList.Where(x => x.PassengerList.Exists(y => y.LastName == lastName)).ToList();
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public List<Fligth> SearchByPassengerPassport(string passport)
        {
            return _flightList.Where(x => x.PassengerList.Exists(y => y.Passport == passport)).ToList();
        }

        /// <exception cref="ArgumentNullException">Параметр <paramref name="source" /> имеет значение null.</exception>
        public List<Fligth> SearchByCity(string city)
        {
            return _flightList.Where(x => x.City == city).ToList();
        }


        public List<Passenger> GetPassengersList(int flightNumber)
        {
            return (List<Passenger>) _flightList.Where(x => x.FlightNumber == flightNumber).Select(x => x.PassengerList);
        }
    }
}