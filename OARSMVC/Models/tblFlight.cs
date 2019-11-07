using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OARSMVC.Models
{
    public class tblFlight
    {
        public int FlightID { get; set; }
        public string FlightNumber { get; set; }
        public string FlightOrigin { get; set; }
        public string FlightDestination { get; set; }
        public System.TimeSpan ArrivalTime { get; set; }
        public System.TimeSpan DestinationTime { get; set; }
        public decimal FareDetails { get; set; }
        public int NoOfSeats { get; set; }
    }
}