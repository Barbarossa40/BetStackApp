using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetStackApp.Persistence.Repos
{
    public class CompetitorRespository: BaseRepository<Competitor>, ICompetitorRepository
    {
        public CompetitorRespository(BetStackAppDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> AreCompetitorNameAndHomeBaseUnique(string name, string homeBase)
        {
            var duplicateCompetitor = _dbContext.Competitors.Any(c => c.Name == name && c.HomeBase == homeBase);

            return Task.FromResult(duplicateCompetitor);
        }
    }
}
