using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> bookings = new List<Booking>();
        private int nextId = 1;
        public IEnumerable<Booking> AsEnumerable()
        {
            return bookings;
        }

        public void Add(Booking booking)
        {
            booking.Id = nextId++;
            bookings.Add(booking);
        }
    }
}