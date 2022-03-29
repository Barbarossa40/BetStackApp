using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorsList
{
    public class GetCompetitorListQuery : IRequest<List<CompetitorsListVM>>
    {
    }
}
