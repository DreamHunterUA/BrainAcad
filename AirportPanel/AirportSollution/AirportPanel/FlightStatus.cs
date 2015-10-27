using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPanel
{
    public enum FlightStatus
    {
        checkIn,
        gateClosed,
        arrived,
        departedAt,
        unknown,
        canceled,
        expectedAt,
        delayed,
        inFlight
    }
}
