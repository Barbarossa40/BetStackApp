using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail.GetBetDetailDtos
{
    public class MatchDto
    {

        public Guid MatchId { get; set; }
        public string MatchEventName { get; set; }

        public DateTime MatchDate { get; set; }

        public string Sport { get; set; }

        public string League { get; set; }

    }
}
