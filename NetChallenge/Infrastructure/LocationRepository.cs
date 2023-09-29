﻿using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Location> locations = new List<Location>();
        private int nextId = 1;

        public IEnumerable<Location> AsEnumerable()
        {
            return locations;
        }

        public void Add(Location location)
        {
            location.Id = nextId++;
            locations.Add(location);
        }
    }
}