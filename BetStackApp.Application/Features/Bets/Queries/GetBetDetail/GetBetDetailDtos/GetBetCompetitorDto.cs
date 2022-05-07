using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetailDtos
{
    public class GetBetCompetitorDto
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Notes { get; set; }

        public bool BetOn { get; set; }
    }
}
