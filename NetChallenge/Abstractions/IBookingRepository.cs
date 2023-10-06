using NetChallenge.Domain;
using System;
using System.Collections.Generic;

namespace NetChallenge.Abstractions
{
    public interface IBookingRepository : IRepository<Booking>
    {
        List<Booking> GetBookedOfficeByDay(DateTime startTime, TimeSpan duration, string officeName);
    }
}