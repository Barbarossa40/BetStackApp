using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetsList
{
    public class GetBetsListQuery : IRequest<List<BetsListVM>>
    {
    }
}
