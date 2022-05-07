using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail.GetCompetitorDetailDtos
{
    public class GetCompetitorDetailCompetitorsDto
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public bool BetOn { get; set; }
    }
}

