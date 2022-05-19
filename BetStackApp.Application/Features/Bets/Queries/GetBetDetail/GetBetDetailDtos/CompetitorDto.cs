using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail.GetBetDetailDtos
{
    public class CompetitorDto
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public string HomeBase { get; set; }

    }
}
