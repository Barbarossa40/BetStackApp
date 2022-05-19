using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Contracts.Persistence
{
    public interface IBetRepository: IAsyncRepository<Bet>
    {

        Task<IReadOnlyList<Bet>> GetAllBets(bool includeParlayLegs);


        Task<List<Bet>> GetBetListById(ICollection<Guid> parlayBets);


    }
}
