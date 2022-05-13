using System;
using System.Collections.Generic;

#nullable disable

namespace BookingAPIServices.Models
{
    public partial class FlightDetail
    {
        public FlightDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }
        public short Id { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string ScheduledDays { get; set; }
        public string InstrumentUsed { get; set; }
        public short BusinessSeats { get; set; }
        public short NonBusinessSeats { get; set; }
        public int TicketCost { get; set; }
        public short Rows { get; set; }
        public string Meal { get; set; }
        public string Tag { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
