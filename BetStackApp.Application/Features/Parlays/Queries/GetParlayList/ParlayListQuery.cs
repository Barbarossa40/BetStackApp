using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayList
{
    public class ParlayListQuery : IRequest<List<ParlayListVm>>
    {
    }
}
