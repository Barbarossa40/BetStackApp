using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Matches.Queries.GetMatchDetail
{
    public class GetMatchDetailQuery: IRequest<GetMatchDetailVm>
    {
       public Guid MatchId { get; set; }  
    }
}
