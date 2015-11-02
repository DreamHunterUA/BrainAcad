using System;
using System.Runtime;
using System.Text;

namespace AirlineInfo
{
    public struct Passenger
    {
        public string FirstName;
        public string LastName;
        public string Passport;
        public string Nationality;
        public DateTime DateOfBirth;
        public Gender Sex;
        public FlightClass FlightClass;
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("First Name - {0}",FirstName ));
            sb.AppendLine(String.Format("Last Name - {0}",LastName ));
            sb.AppendLine(String.Format("Nationality - {0}",Nationality ));
            sb.AppendLine(String.Format("Passport - {0}",Passport ));
            sb.AppendLine(String.Format("Date of birth - {0}",DateOfBirth ));
            sb.AppendLine(String.Format("Sex - {0}",Sex ));
            sb.AppendLine(String.Format("Flight Class - {0}",FlightClass == FlightClass.Economy?"Economy Class":"Business Class" ));
            return sb.ToString();

        }
    }
}