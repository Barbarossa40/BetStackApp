using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail
{
    public class GetParlayDetailQuery: IRequest<ParlayDetailVm>
    {
        public Guid ParlayId { get; set; }
    }
}
