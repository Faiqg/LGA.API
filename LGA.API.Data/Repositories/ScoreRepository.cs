using LGA.API.Data.Contracts;
using LGA.API.Model;

namespace LGA.API.Data.Repositories
{
    public class ScoreRepository : BaseRepository<Score>, IScoreRepository
    {
        public ScoreRepository(LGAContext context) : base(context)
        {

        }
    }
}
