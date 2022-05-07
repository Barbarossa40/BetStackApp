using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail.GetCompetitorDetailDtos;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class CompetitorDetailsVM
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public string Notes { get; set; }

        public ICollection<GetCompetitorDetailBetDto>? CompetitorBets { get; set; }

    }
}

