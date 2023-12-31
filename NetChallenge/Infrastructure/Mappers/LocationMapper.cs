﻿using NetChallenge.Domain;
using NetChallenge.Dto.Input;
using NetChallenge.Dto.Output;

namespace NetChallenge.Infrastructure.Mappers
{
    public class LocationMapper
    {
        public static LocationDto MapLocationToDto(Location location)
        {
            return new LocationDto
            {
                Name = location.Name,
                Neighborhood = location.Neighborhood
            };
        }

        public static Location MapLocationRequestToLocation(AddLocationRequest location) 
        {
            return new Location
            {
                Name = location.Name,
                Neighborhood = location.Neighborhood
            };
        }
    }
}
