using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NetChallenge.Infrastructure.Mappers
{
    public class OfficeMapper
    {
        public static OfficeDto MapOfficeToDto(Office office, Location location)
        {
            return new OfficeDto
            {
                Name = office.Name,
                MaxCapacity = office.MaxCapacity,
                AvailableResources = office.AvailableResources.ToArray(),
                LocationName = location.Name
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
