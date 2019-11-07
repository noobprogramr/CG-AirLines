using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OARSMVC.Models
{
    public class tblGuest
    {
        public int GuestID { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public long GuestPhoneNo { get; set; }
        public Nullable<int> GuestAge { get; set; }
        public string GuestGender { get; set; }
    }
}