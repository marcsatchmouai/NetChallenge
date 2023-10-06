using NetChallenge.Domain;

namespace NetChallenge.Abstractions
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetLocationByName(string Name);
    }
}