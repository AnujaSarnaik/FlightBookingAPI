using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesAPIServices.Models
{
    public class MockAirlines : IAirlinesRepository
    {
        List<AirlinesDetails> flightList = new List<AirlinesDetails>();
        List<Booking> bookingList = new List<Booking>();
        FlightDBContext _context;
        public MockAirlines(FlightDBContext context)
        {
            _context = context;
        }

        public string GetLoginDetails(string userName, string password)
        {
            string role = _context.Logins
                .Where(l => l.UserName.Equals(userName) && l.Password.Equals(password))
                .Select(l => l.Role)
                .FirstOrDefault();
                

            return role;
        }
        public void addFlight(FlightDetail flightDetail)
        {
            _context.FlightDetails.Add(flightDetail);
            _context.SaveChanges();
            //string flightId = flightList
            //    .Where(f => f.id.Equals(selectedFlightId))
            //    .Select(f => f.id)
            //    .FirstOrDefault();

            //if(flightId != null)
            //{
            //    passengerDetails[] passengerDetailsList = new passengerDetails [2];
            //    passengerDetailsList[0].name = "Rutuja";
            //    passengerDetailsList[0].gender = "Female";
            //    passengerDetailsList[0].age = 30;

            //    Booking bookingDetails = new Booking();
            //    bookingDetails.flightId = flightId;
            //    bookingDetails.PNR = DateTime.Now.ToString() + flightId;
            //    bookingDetails.name = "abc";
            //    bookingDetails.details = passengerDetailsList;
            //    bookingDetails.mailId = "abc23@gmail.com";
            //    bookingList.Add(bookingDetails);
            //}
            
     
        }
        public List<FlightDetail> GetAirlines()
        {
            return _context.FlightDetails.ToList();
        }

        public Airlines GetAirlineByNumber(string flightNumber)
        {
            Airlines selectedAirline = _context.FlightDetails
                 .Where(f => f.FlightNumber.Equals(flightNumber))
                 .Select(a => new Airlines { id= a.Id,flightDate = a.Date, flightNumber = a.FlightNumber, price = a.TicketCost })
                 .FirstOrDefault();

            return selectedAirline;
        }

        public List<Airlines> GetAirlineByDate(DateTime date)
        {
            List<Airlines> selectedAirline;
            selectedAirline = _context.FlightDetails
                    .Where(f => f.Date.Equals(date))
                    .Select(a => new Airlines { id = a.Id, flightDate = a.Date, flightNumber = a.FlightNumber, price = a.TicketCost })
                    .ToList();
                //List<Airlines> selectedAirline = flightList
                //     .Where(f => f.flightDate.Equals(date))
                //     .Select(a => new Airlines { id = a.id, flightDate = a.flightDate, flightName = a.flightName, price = a.price })
                //     .ToList();
            
            return selectedAirline;
        }
        public void deleteFlight(string flightNumber)
        {
            FlightDetail flightDetailEntry;
            flightDetailEntry = _context.FlightDetails
                .Where(f => f.FlightNumber.Equals(flightNumber))
                .FirstOrDefault();
            if(flightDetailEntry != null)
            {
                _context.FlightDetails.Remove(flightDetailEntry);
                _context.SaveChanges();
            }

        }
    }
}
