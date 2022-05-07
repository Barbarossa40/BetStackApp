using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Contracts.Persistence
{
    public interface IBetCompetitorRepository : IAsyncRepository<BetCompetitor>
    {

        Task<IEnumerable<Bet>> GetAllBetsByCompetitor(Guid CompId);  // need to .Include( sport and league and betcompetitor)
        //Task<bool> IsBetAndDateComboUnique(Guid eventName, DateTime betCompletion); //may want to change to compId instead of name since we could have multi[pple bets under one comp
    }
}
