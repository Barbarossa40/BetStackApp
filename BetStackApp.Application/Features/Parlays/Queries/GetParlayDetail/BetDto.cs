using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetail.GetBetDetailDtos;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail
{
    public  class BetDto
    {
        public Guid BetId { get; set; }

        public MatchDto MatchBetOn { get; set; }
        public DateOnly DatePlaced { get; set; }

        public double Odds { get; set; }

        public bool WinBet { get; set; }

        public CompetitorDto BetOn { get; set; }

        public CompetitorDto BetAgainst { get; set; }

        public bool IsComplete { get; set; }
    }
}
