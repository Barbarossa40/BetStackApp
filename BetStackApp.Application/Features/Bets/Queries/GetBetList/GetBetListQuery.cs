using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetList
{
    public class GetBetListQuery : IRequest<List<BetListVm>>
    {
        public bool includeParlayLegs { get; set; }
    }
}
