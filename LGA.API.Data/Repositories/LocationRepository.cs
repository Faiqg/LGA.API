using LGA.API.Data.Contracts;
using LGA.API.Model;

namespace LGA.API.Data.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(LGAContext context) : base(context)
        {

        }
    }
}
