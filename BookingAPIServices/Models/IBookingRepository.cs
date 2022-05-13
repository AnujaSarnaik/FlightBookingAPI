using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIServices.Models
{
    public interface IBookingRepository
    {
        public string bookFlight(BookingDetail bookingDetail);
    }
}
