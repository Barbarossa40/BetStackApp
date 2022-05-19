using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail
{
    public class GetBetDetailQuery: IRequest<BetDetailVm>
    {
        public Guid BetId { get; set; }

    }
}
