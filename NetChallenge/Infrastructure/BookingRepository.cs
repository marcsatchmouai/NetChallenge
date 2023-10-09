using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Exceptions;

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

        public List<Booking> GetBookedOfficeByDay(DateTime dateTime, TimeSpan duration, string officeName) 
        {
            DateTime finishTime = dateTime.Add(duration);

            return bookings.Where(o => o.OfficeName == officeName && (o.DateTime.Add(o.Duration) >= dateTime || o.DateTime <= finishTime)).ToList();
        }
    }
}