using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class FlightReservationSystem : Program
    {
        public List<Flight> Flights { get; set; }
        public List<Reservation> Reserv { get; set; }

        public FlightReservationSystem()
        {
            Flights = new List<Flight>();
            Reserv = new List<Reservation>();
        }

        public List<Flight> SearchFlights(string departureCity, string arrivalCity, DateTime departureDate)
        {
            List<Flight> flightsFound = new List<Flight>();
            foreach (Flight flight in Flights)
            {
                if (flight.DepartureCity.Equals(departureCity, StringComparison.OrdinalIgnoreCase) &&
                    flight.ArrivalCity.Equals(arrivalCity, StringComparison.OrdinalIgnoreCase) &&
                    flight.DepartureTime.Date == departureDate.Date)
                {
                    flightsFound.Add(flight);
                }
            }
            return flightsFound;
        }

        public void BookTicket(Flight flight, string passengerName)
        {
            if (flight.AvailableSeats > 0)
            {
                string reservationNumber = Guid.NewGuid().ToString();
                Reservation reservation = new Reservation
                {
                    ReservationNumber = reservationNumber,
                    PassengerName = passengerName,
                    Flight = flight
                };
                Reserv.Add(reservation);
                flight.AvailableSeats--;
                Console.WriteLine("Bileti Dajavshnilia. Tkveni Javshnis nomeri: " + reservationNumber);
            }
            else
            {
                Console.WriteLine("Kvela bileti gakidulia");
            }
        }

        public void CancelReservation(Reservation reservation)
        {
            Reserv.Remove(reservation);
            reservation.Flight.AvailableSeats++;
            Console.WriteLine("Bileti Gauqmebulia Srulkopilad");
        }
    }
}
