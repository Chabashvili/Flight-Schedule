using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightReservationSystem reservationSystem = new FlightReservationSystem();

            Flight flight1 = new Flight
            {
                FlightNumber = "FL001",
                DepartureCity = "New York",
                ArrivalCity = "Los Angeles",
                DepartureTime = new DateTime(2023, 6, 21),
                AvailableSeats = 100
            };

            Flight flight2 = new Flight
            {
                FlightNumber = "FL002",
                DepartureCity = "London",
                ArrivalCity = "Paris",
                DepartureTime = new DateTime(2023, 6, 21),
                AvailableSeats = 50
            };

            Flight flight3 = new Flight
            {
                FlightNumber = "FL003",
                DepartureCity = "Tokyo",
                ArrivalCity = "Sydney",
                DepartureTime = new DateTime(2023, 6, 22),
                AvailableSeats = 20
            };

            reservationSystem.Flights.AddRange(new List<Flight> { flight1, flight2, flight3 });
            while (true)
            {
                Console.WriteLine("Flight System");
                Console.WriteLine("1 - Modzebne Prenebi");
                Console.WriteLine("2 - Dajavshne Bileti");
                Console.WriteLine("3 - Gaauqme Bileti");
                Console.WriteLine("4 - Gamosvla");

                Console.Write("Chaweret tkveni archevani: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter departure city: ");
                        string departureCity = Console.ReadLine();

                        Console.Write("Enter arrival city: ");
                        string arrivalCity = Console.ReadLine();

                        Console.Write("Sheikvanet Tarigi");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime departureDate))
                        {

                            List<Flight> availableFlights = reservationSystem.SearchFlights(departureCity, arrivalCity, departureDate);

                            if (availableFlights.Count > 0)
                            {

                                Console.WriteLine("Xelmisawvdomi Prenebi");

                                foreach (Flight flight in availableFlights)
                                {
                                    Console.WriteLine($"Flight Number: {flight.FlightNumber}");

                                    Console.WriteLine($"Departure City: {flight.DepartureCity}");

                                    Console.WriteLine($"Arrival City: {flight.ArrivalCity}");

                                    Console.WriteLine($"Departure Time: {flight.DepartureTime}");

                                    Console.WriteLine($"Available Seats: {flight.AvailableSeats}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Prena ar aris xelmisawvdomi tkveni kriteriumebit");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Araswori Tarigi");
                        }
                        break;

                    case "2":
                        Console.Write("Sheiyvanet tkveni prenis kodi");
                        string flightNumber = Console.ReadLine();

                        Flight selectedFlight = reservationSystem.Flights.Find(flight => flight.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase));
                        if (selectedFlight != null)
                        {
                            Console.Write("Sheiyvanet pasajiris saxeli");
                            string passengerName = Console.ReadLine();

                            reservationSystem.BookTicket(selectedFlight, passengerName);
                        }
                        else
                        {
                            Console.WriteLine("Kodi Arasworia");
                        }
                        break;

                    case "3":
                        Console.Write("Sheiyvanet rezervis kodi ");
                        string reservationNumber = Console.ReadLine();

                        Reservation selectedReservation = reservationSystem.Reserv.Find(reservation => reservation.ReservationNumber.Equals(reservationNumber, StringComparison.OrdinalIgnoreCase));
                        if (selectedReservation != null)
                        {
                            reservationSystem.CancelReservation(selectedReservation);
                        }
                        else
                        {
                            Console.WriteLine("Araswori reservis kodi");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Gamosvla");
                        return;

                    default:
                        Console.WriteLine("Arasworia. Sheiyvanet cipri 1 dan 4 amde");
                        break;
                }
            }
        }
    }
}
