using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel
{
    public struct Flight
    {

        public int flightNumber;
        public string city;
        public string airline;
        public int terminal;
        public FlightStatus flightStatus;
        public string gate;

        private Dictionary<FlightStatus, string> FligthStatusDictionary
        {
            get
            {
                return new Dictionary<FlightStatus, string>
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
            }

        }

        public override string ToString()
        {
            string currentStatus;
            if (!FligthStatusDictionary.TryGetValue(flightStatus,out currentStatus))
                currentStatus = "Unknown";
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Flight number - {0}", flightNumber));
            sb.AppendLine(string.Format("City - {0}", city));
            sb.AppendLine(string.Format("Airline - {0}", airline));
            sb.AppendLine(string.Format("Terminal - {0}", terminal));
            sb.AppendLine(string.Format("Status - {0}", currentStatus));
            sb.AppendLine(string.Format("Gate - {0}", gate));
            
            return sb.ToString();
        }
    }
}
