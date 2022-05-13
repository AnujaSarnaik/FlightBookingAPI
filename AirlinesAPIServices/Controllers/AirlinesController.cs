using AirlinesAPIServices.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlinesAPIServices.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        public IAirlinesRepository _airlines;
        private FlightDBContext _context;
        public AirlinesController(IAirlinesRepository airlines, FlightDBContext context)
        {
            _airlines = airlines;
            _context = context;
        }

        [Route("api/Airlines/GetLoginDetails/{userName}/{password}")]
        [HttpGet]
        public string GetLoginDetails(string userName, string password)
        {
            return _airlines.GetLoginDetails(userName,password);
        }

        [Route("api/Airlines/GetFlights")]
        [HttpGet]
        public List<FlightDetail> GetFlights()
        {
            return _airlines.GetAirlines();
        }

        [Route("api/Airlines/GetFlightByNumber/{flightNumber}")]
        [HttpGet]
        public Airlines GetAirlineByNumber(string flightNumber)
        {
            return _airlines.GetAirlineByNumber(flightNumber);
        }

        //[Route("GetFlightByDate/{flightDate}")]
        [Route("api/Airlines/GetFlightByDate/{flightDate}")]
        [HttpGet]
        public List<Airlines> GetFlightByDate(string flightDate)
        {
            List<Airlines> airlineList = new List<Airlines>();
            DateTime fDate;
            if (flightDate != null)
            {
                fDate = DateTime.Parse(flightDate);
                airlineList = _airlines.GetAirlineByDate(fDate);
            }

            return airlineList;
        }
        // GET: api/<HomeController>
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [Route("api/[controller]")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>

        [Route("api/Airlines/Post")]
        [HttpPost("{value}")]
        public string Post([FromBody] string value)
        // public void Post()
        {
            return value;
        }

        // PUT api/<HomeController>/5
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [Route("api/[controller]")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("api/Airlines/DeleteFlight/{flightNumber}")]
        [HttpDelete]
        public void DeleteFlight(string flightNumber)
        {
            _airlines.deleteFlight(flightNumber);
        }


        [Route("api/Airlines/AddFlight")]
        [HttpPost("{flightDetail}")]
        public void AddFlight([FromBody] FlightDetail flightDetail)
        {
            flightDetail.Tag = DateTime.Now.ToString()+flightDetail.FlightNumber;
            _airlines.addFlight(flightDetail);
        }
    }
}
