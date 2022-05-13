using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesAPIServices.Models
{
    public interface IAirlinesRepository
    {
        public List<FlightDetail> GetAirlines();
        public Airlines GetAirlineByNumber(string flightNumber);

        public List<Airlines> GetAirlineByDate(DateTime flightName);

        public void addFlight(FlightDetail flightDetail);

        public void deleteFlight(string flightNumber);

        public string GetLoginDetails(string userName, string password);

    }
}
