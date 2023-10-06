using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Infrastructure.Mappers
{
    public class BookingMapper
    {
        public static BookingDto MapBookingToDto(Booking booking)
        {
            return new BookingDto
            {
                LocationName = booking.LocationName,
                OfficeName = booking.OfficeName,
                DateTime = booking.StartTime,
                Duration = booking.Duration,
                UserName = booking.UserName
            };
        }

        public static Booking MapBookingRequestToBooking(BookOfficeRequest booking)
        {
            return new Booking
            {
                LocationName = booking.LocationName,
                OfficeName = booking.OfficeName,
                StartTime = booking.DateTime,
                Duration = booking.Duration,
                UserName = booking.UserName
            };
        }
    }
}
