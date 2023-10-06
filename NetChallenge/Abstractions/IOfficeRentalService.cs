﻿using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallenge.Abstractions
{
    public interface IOfficeRentalService
    {
        void AddLocation(AddLocationRequest request);
        IEnumerable<LocationDto> GetLocations();
        void AddOffice(AddOfficeRequest request);
        IEnumerable<OfficeDto> GetOffices(int locatioId);
        void BookOffice(BookOfficeRequest request);
        IEnumerable<BookingDto> GetBookings(string officeName);
        IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request);
    }
}
