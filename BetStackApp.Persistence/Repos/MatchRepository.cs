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
    public class MatchRepository: BaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(BetStackAppDbContext dbContext): base(dbContext)
        {


        }

        public Task<bool> AreMatchNameAndDateUnique(string matchEventName, DateTime matchDate)
        {
            var duplicateMatch =_dbContext.Matches.Any(n=>n.MatchEventName.Equals(matchEventName) && n.MatchDate.Equals(matchDate.Date));

            return  Task.FromResult(duplicateMatch);
        }
    }
}
