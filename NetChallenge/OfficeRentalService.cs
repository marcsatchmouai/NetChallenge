using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Exceptions;
using NetChallenge.Infrastructure.Mappers;

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
            try
            {
                if ((GetLocations().Where(l => l.Name == request.Name).Count()) > 0)
                {
                    ExceptionHandler.HandleException(new ArgumentException("El nombre de la localizacion no puede repetirse."));
                };

                var location = new Location
                {
                    Name = request.Name,
                    Neighborhood = request.Neighborhood
                };

                _locationRepository.Add(location);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleExceptionAndReturnEmpty<LocationDto>(ex, $"Error al agregar ubicación: {ex.Message}");
            }
        }

        public void AddOffice(AddOfficeRequest request)
        {
            try
            {
                Office office = OfficeMapper.MapOfficeRequestToOffice(request);

                if (!GetLocations().Where(l => l.Name == request.LocationName).Any())
                {
                    ExceptionHandler.HandleException(new InvalidOperationException("El nombre de la localizacion no existe."));
                };
                
                if (GetOffices(request.LocationName).Where(o => o.Name == request.Name).Any()) 
                {
                    ExceptionHandler.HandleException(new InvalidOperationException("El nombre de la oficina ya existe en la localizacion."));
                }

                ValidationExtensions.ValidateNotLessThanOrEqualZero(office.MaxCapacity, "La capacidad debe ser mayor que cero.");

                _officeRepository.Add(office);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleExceptionAndReturnEmpty<LocationDto>(ex, $"Error al agregar oficina: {ex.Message}");
            }
        }

        public void BookOffice(BookOfficeRequest request)
        {
            try
            {
                Booking bookOffice = BookingMapper.MapBookingRequestToBooking(request);

                ValidationExtensions.ValidateNotInPast(bookOffice.DateTime, "La fecha de reserva no puede ser en el pasado.");

                if (_bookingRepository.GetBookedOfficeByDay(bookOffice.DateTime, bookOffice.Duration, bookOffice.OfficeName).Any())
                {
                    throw new InvalidOperationException("La oficina se encuentra reservada en la fecha seleccionada");
                }

                _bookingRepository.Add(bookOffice);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleExceptionAndReturnEmpty<LocationDto>(ex, $"Error al realizar reserva: {ex.Message}");
            }
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            locationName.ValidateNotNullOrEmpty(nameof(locationName));

            officeName.ValidateNotNullOrEmpty(nameof(officeName));

            try
            {
                IEnumerable<Booking> bookings = _bookingRepository.AsEnumerable().Where(b => b.OfficeName == officeName && b.LocationName == locationName);

                return bookings?.Select(BookingMapper.MapBookingToDto) ?? Enumerable.Empty<BookingDto>();
            }
            catch (Exception ex)
            {
                return ExceptionHandler.HandleExceptionAndReturnEmpty<BookingDto>(ex, $"Error al obtener las reservas: {ex.Message}");
            }
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            try
            {
                IEnumerable<Location> locations = _locationRepository.AsEnumerable();

                return locations?.Select(LocationMapper.MapLocationToDto) ?? Enumerable.Empty<LocationDto>();
            }
            catch (Exception ex)
            {
                return ExceptionHandler.HandleExceptionAndReturnEmpty<LocationDto>(ex, $"Error al obtener las locaciones: {ex.Message}");
            }
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            locationName.ValidateNotNullOrEmpty(nameof(locationName));

            try
            {
                IEnumerable<Office> offices = _officeRepository.AsEnumerable().Where(o => o.LocationName == locationName);

                return offices?.Select(OfficeMapper.MapOfficeToDto) ?? Enumerable.Empty<OfficeDto>();
            }
            catch (Exception ex)
            {
                return ExceptionHandler.HandleExceptionAndReturnEmpty<OfficeDto>(ex, $"Error al obtener las oficinas: {ex.Message}");
            }
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            try
            {
                var suggestions = _officeRepository.AsEnumerable()
                    .Where(office => office.MaxCapacity >= request.CapacityNeeded && request.ResourcesNeeded
                        .All(resource => office.AvailableResources.Contains(resource)))
                    .OrderBy(office => office.MaxCapacity)
                    .ThenBy(office => office.AvailableResources.Count())
                    .ThenBy(office => office.LocationName == request.PreferedNeigborHood ? 0 : 1, Comparer<int>.Default)
                    .ToList();

                return suggestions.Select(OfficeMapper.MapOfficeToDto);
            }
            catch (Exception ex)
            {
                return ExceptionHandler.HandleExceptionAndReturnEmpty<OfficeDto>(ex, $"Error al obtener sugerencias de oficinas: {ex.Message}");
            }
        }
    }
}