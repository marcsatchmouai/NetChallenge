using System;
using System.Collections.Generic;
using System.Linq;
using NetChallenge.Abstractions;
using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using NetChallenge.Infrastructure;
using NetChallenge.Infrastructure.Common;
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
                var location = new Location
                {
                    Name = request.Name,
                    Neighborhood = request.Neighborhood
                };

                _locationRepository.Add(location);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Response AddOffice(AddOfficeRequest request)
        {
            Response response = new Response();

            try
            {
                Office office = OfficeMapper.MapOfficeRequestToOffice(request);

                _officeRepository.Add(office);
                return response;
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return response;
            }
        }

        public Response BookOffice(BookOfficeRequest request)
        {
            Response response = new Response();

            try
            {
                Booking bookOffice = BookingMapper.MapBookingRequestToBooking(request);

                if (_bookingRepository.GetBookedOfficeByDay(bookOffice.StartTime, bookOffice.Duration, bookOffice.OfficeName).Any()) 
                {
                    response.AddError("La oficina se encuentra reservada en la fecha seleccionada");
                    return response;
                }

                _bookingRepository.Add(bookOffice);
                return response;
                
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return response;
            }
        }

        public IEnumerable<BookingDto> GetBookings(string officeName)
        {
            var bookings = _bookingRepository.AsEnumerable().Where(b => b.OfficeName == officeName);
            return bookings.Select(BookingMapper.MapBookingToDto);
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var locations = _locationRepository.AsEnumerable();
            return locations.Select(LocationMapper.MapLocationToDto);
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var offices = _officeRepository.AsEnumerable().Where(o => o.LocationName == locationName);
            return offices.Select(OfficeMapper.MapOfficeToDto);
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            // Implementa la lógica para obtener sugerencias de oficinas según las especificaciones
            // Puedes usar LINQ para filtrar y ordenar las oficinas disponibles
            var offices = _officeRepository.AsEnumerable();

            // Aplica filtros según la capacidad, recursos, barrio, etc.

            // Ordena las oficinas por conveniencia

            // Retorna las oficinas sugeridas en formato DTO
            return offices.Select(OfficeMapper.MapOfficeToDto);
        }
    }
}