using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class GetCompetitorDetailsQuery : IRequest<CompetitorDetailsVM>
    {
        public Guid CompetitorId { get; set; }
    }
}
