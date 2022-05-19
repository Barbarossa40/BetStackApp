using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BetStackApp.Persistence.Repos
{
    public class BetRespository : BaseRepository<Bet>, IBetRepository
    {
        public BetRespository(BetStackAppDbContext dbContext) : base(dbContext)
        {

        }
  
        public async Task<IReadOnlyList<Bet>> GetAllBets(bool includeParlayLeg)
        {
            var allBets = await _dbContext.Bets
                          .Include(x => x.MatchBetOn)
                          .Include(y => y.BetOn)
                          .Include(z => z.BetAgainst).ToListAsync();
            if (!includeParlayLeg)
            {
                foreach(Bet bet in allBets)
                {
                    if (bet.IsParlayLeg)
                    {
                        allBets.Remove(bet);
                    }
                }
            }

            return allBets; 
            
        }

        public async Task<List<Bet>> GetBetListById(ICollection<Guid> parlayBets)
        {
            List<Bet> betList = new List<Bet>();
            foreach (Guid id in parlayBets)
            {
               Bet bet = await GetByIdAsync(id);
                betList.Add(bet);

            }

            return betList;
        }
    }
}
