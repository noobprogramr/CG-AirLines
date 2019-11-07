using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OARSMVC.Models
{
    public class Passenger
    {
        public GuestSeat seats { get; set; }
        [Display(Name = "Enter Date")]
        public DateTime EnterDate { get; set; }
    }
    public enum GuestSeat
    {
        One=1,
        Two=2,
        Three=3
    }
   
}