using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesAPIServices.Models
{
    public class Booking
    {
        public string flightId { get; set; }

        public string name { get; set; }
        public string mailId { get; set; }
        public string[] seatNos { get; set; }

        public string PNR { get; set; }

        public passengerDetails[] details {get; set;}

    }
    public class passengerDetails
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}
