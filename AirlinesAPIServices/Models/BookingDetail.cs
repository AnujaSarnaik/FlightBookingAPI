using System;
using System.Collections.Generic;

#nullable disable

namespace AirlinesAPIServices.Models
{
    public partial class BookingDetail
    {
        public long Id { get; set; }
        public string EmailId { get; set; }
        public short? NoOfSeats { get; set; }
        public string Meal { get; set; }
        public string SeatNo { get; set; }
        public string FlightNumber { get; set; }
        public string Pnr { get; set; }

        public virtual FlightDetail FlightNumberNavigation { get; set; }
    }
}
