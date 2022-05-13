using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlinesAPIServices.Models
{
    public class Airlines
    {
        public short id { get; set; }
        public DateTime flightDate { get; set; }

        public string flightNumber { get; set; }
        public float price { get; set; }

    }
    public class AirlinesDetails : Airlines
    {
        public string from { get; set; }

        public string to { get; set; }

    }
}
