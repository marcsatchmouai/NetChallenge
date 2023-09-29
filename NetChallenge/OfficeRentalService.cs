using System;
using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Infrastructure;

namespace NetChallenge
{
    public class OfficeRentalService : IOfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void AddLocation(AddLocationRequest request)
        {
            var location = new Location
            {
                Name = request.Name,
                Neighborhood = request.Neighborhood
            };

            _locationRepository.Add(location);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            // Validaciones y mapeo de DTO a entidad Office
            var office = new Office
            {
                Name = request.Name,
                MaxCapacity = request.MaxCapacity,
                Resources = request.LocationName,
                LocationId = request.
            };

            _officeRepository.Add(office);
        }

        public void BookOffice(BookOfficeRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var locations = _locationRepository.AsEnumerable();
            return locations.Select(MapLocationToDto);
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}