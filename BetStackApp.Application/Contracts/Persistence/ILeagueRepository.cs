using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Contracts.Persistence
{
    public interface ILeagueRepository : IAsyncRepository<League>
    {
    }
}
