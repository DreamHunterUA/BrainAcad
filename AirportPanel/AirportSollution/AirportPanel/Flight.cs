using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel
{
    public struct Flight
    {

        public int FlightNumber;
        public string City;
        public string Airline;
        public string Terminal;
        public FlightStatus FlightStatus;
        public int Gate;
        public DateTime Date;

        

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

        /// <exception cref="ArgumentOutOfRangeException">При увеличении значения данного экземпляра будет превышено значение <see cref="P:System.Text.StringBuilder.MaxCapacity" />. </exception>
        public override string ToString()
        {
            string currentStatus;
            if (!FligthStatusDictionary.TryGetValue(FlightStatus,out currentStatus))
                currentStatus = "Unknown";
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Flight number - {0}", FlightNumber));
            sb.AppendLine(String.Format("Date - {0}", Date));
            sb.AppendLine(String.Format("City - {0}", City));
            sb.AppendLine(String.Format("Airline - {0}", Airline));
            sb.AppendLine(String.Format("Terminal - {0}", Terminal));
            sb.AppendLine(String.Format("Status - {0}", currentStatus));
            sb.AppendLine(String.Format("Gate - {0}", Gate));
            
            return sb.ToString();
        }
    }
}
