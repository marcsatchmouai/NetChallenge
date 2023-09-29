using System.Collections.Generic;
using NetChallenge.Abstractions;
using NetChallenge.Domain;

namespace NetChallenge.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly List<Office> offices = new List<Office>();
        private int nextId = 1;
        public IEnumerable<Office> AsEnumerable()
        {
            return offices;
        }

        public void Add(Office office)
        {
            office.Id = nextId++;
            offices.Add(office);
        }
    }
}