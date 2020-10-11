using LGA.API.Data.Contracts;
using LGA.API.Model;

namespace LGA.API.Data.Repositories
{
    class ScoreDetailRepository : BaseRepository<ScoreDetail>, IScoreDetailRepository
    {
        public ScoreDetailRepository(LGAContext context) : base(context)
        {

        }
    }
}
