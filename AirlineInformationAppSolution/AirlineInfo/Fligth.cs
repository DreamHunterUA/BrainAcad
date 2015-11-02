using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AirlineInfo
{
    public class Fligth
    {
        private int _flightNumber;
        private string _city;
        private string _airline;
        private string _terminal;
        private FlightStatus _flightStatus;
        private int _gate;
        private DateTime _date;
        private List<Passenger> _passengerList = new List<Passenger>();
        private decimal _businessClassPrice;
        private decimal _economyClassPrice;
        private Dictionary<FlightStatus, string> FligthStatusDictionary => new Dictionary<FlightStatus, string>
        {
            {FlightStatus.arrived,"Arrived" },
            {FlightStatus.canceled,"Canceled" },
            {FlightStatus.checkIn ,"CheckIn" },
            {FlightStatus.delayed,"Delayed" },
            {FlightStatus.departedAt,"Departed at" },
            {FlightStatus.expectedAt,"Expected at" },
            {FlightStatus.gateClosed,"Gate closed" },
            {FlightStatus.inFlight,"In fligth" },
            {FlightStatus.unknown,"Unknown" }
        };
        public int FlightNumber
        {
            get { return _flightNumber; }
            set { _flightNumber = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Airline
        {
            get { return _airline; }
            set { _airline = value; }
        }

        public string Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }

        public FlightStatus Status
        {
            get { return _flightStatus; }
            set { _flightStatus = value; }
        }

        public int Gate
        {
            get { return _gate; }
            set { _gate = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public List<Passenger> PassengerList
        {
            get { return _passengerList; }           
        }

        public decimal BusinessClassPrice
        {
            get { return _businessClassPrice; }
            set { _businessClassPrice = value; }
        }

        public decimal EconomyClassPrice
        {
            get { return _economyClassPrice; }
            set { _economyClassPrice = value; }
        }

        /// <exception cref="NullReferenceException">Значение параметра <paramref name="name" /> равно null. </exception>
        /// <exception cref="CultureNotFoundException">Значение параметра <paramref name="name" /> не является допустимым именем языка и региональных параметров.– или – Язык и региональные параметры, заданные параметром <paramref name="name" />, не имеет соответствующего ему определенного языка и региональных параметров. </exception>
        public override string ToString()
        {
            string currentStatus;
            if (!FligthStatusDictionary.TryGetValue(Status, out currentStatus))
                currentStatus = "Unknown";
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Flight number - {0}", FlightNumber));
            sb.AppendLine(String.Format("Date - {0}", Date));
            sb.AppendLine(String.Format("City - {0}", City));
            sb.AppendLine(String.Format("Airline - {0}", Airline));
            sb.AppendLine(String.Format("Terminal - {0}", Terminal));
            sb.AppendLine(String.Format("Status - {0}", currentStatus));
            sb.AppendLine(String.Format("Gate - {0}", Gate));
            sb.AppendLine(String.Format(CultureInfo.CreateSpecificCulture("en-US"), "EconomyClassPrice - {0}", EconomyClassPrice));
            sb.AppendLine(String.Format(CultureInfo.CreateSpecificCulture("en-US"), "BusinessClassPrice - {0}", BusinessClassPrice));
            return sb.ToString();

        }
    }
}