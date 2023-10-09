using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System.Linq;

namespace NetChallenge.Infrastructure.Mappers
{
    public class OfficeMapper
    {
        public static OfficeDto MapOfficeToDto(Office office)
        {
            return new OfficeDto
            {
                Name = office.Name,
                MaxCapacity = office.MaxCapacity,
                AvailableResources = office.AvailableResources.ToArray(),
                LocationName = office.LocationName
            };
        }

        public static Office MapOfficeRequestToOffice(AddOfficeRequest office) 
        {
            return new Office
            {
                Name = office.Name,
                MaxCapacity = office.MaxCapacity,
                AvailableResources = office.AvailableResources,
                LocationName = office.LocationName
            };
        }
    }
}
