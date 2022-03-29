using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Leagues.Queries.GetLeaguesList
{
    public class GetLeaguesListQuery : IRequest<List<LeaguesListVM>>
    {
    }
}
