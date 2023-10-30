using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Reservation : Program
    {
        public string ReservationNumber { get; set; }
        public string PassengerName { get; set; }
        public Flight Flight { get; set; }
    }
}
