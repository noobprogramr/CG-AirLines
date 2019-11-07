using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OARSMVC.Models
{
    public class tblBooking
    {
        public int BookingID { get; set; }
        public string BookingPNR { get; set; }
        public System.DateTime DateOfJourney { get; set; }
        public string FlightStatus { get; set; }
        public string BookingTicketStatus { get; set; }
        public Nullable<int> GuestID { get; set; }
        public Nullable<int> FlightID { get; set; }

        public virtual tblFlight tblFlight { get; set; }
        public virtual tblGuest tblGuest { get; set; }
    }
}