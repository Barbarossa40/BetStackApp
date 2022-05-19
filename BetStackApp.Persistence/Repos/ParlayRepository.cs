using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BetStackApp.Persistence.Repos
{
    public class ParlayRepository: BaseRepository<Parlay>, IParlayRepository
    {

        public ParlayRepository(BetStackAppDbContext dbContext) : base(dbContext)
        {

        }
     
    }
}
