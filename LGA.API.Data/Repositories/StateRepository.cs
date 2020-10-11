using LGA.API.Data.Repositories;
using LGA.API.Model;

namespace LGA.API.Data.Contracts
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(LGAContext context) : base(context)
        {
        }
    }
}
