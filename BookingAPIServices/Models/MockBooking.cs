using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPIServices.Models
{
    public class MockBooking : IBookingRepository
    {
        FlightDBContext _context;
        public MockBooking(FlightDBContext context)
        {
            _context = context;
        }
        public string bookFlight(BookingDetail bookingDetail)
        {
            string msg;
            FlightDetail flightDetailEntry = new FlightDetail();
            flightDetailEntry = _context.FlightDetails
                .Where(f => f.FlightNumber.Equals(bookingDetail.FlightNumber))
                .FirstOrDefault();
            if (flightDetailEntry != null)
            {
                _context.BookingDetails.Add(bookingDetail);
                _context.SaveChanges();
                msg = "Flight Booked";
            }
            else
            {
                msg = "Select Proper Flight Number";
            }
            return msg;
        
        }
    }
}

