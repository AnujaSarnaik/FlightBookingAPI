using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingAPIServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAPIServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepository _booking;
        public BookingController(IBookingRepository booking)
        {
            _booking = booking;
        }

        [Route("bookFlight/{flightId}")]
        [HttpPost]
        public void bookFlight(string flightId)
        {
            //_airlines.bookFlight(flightId);
        }

       
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("api/Booking/bookFlight")]
        [HttpPost("{bookingDetail}")]
        public string bookFlight([FromBody] BookingDetail bookingDetail)
        {
            string msg;
            bookingDetail.Pnr = DateTime.Now.ToString() + bookingDetail.EmailId;
           msg= _booking.bookFlight(bookingDetail);
            return (msg);
        }
    }
}
