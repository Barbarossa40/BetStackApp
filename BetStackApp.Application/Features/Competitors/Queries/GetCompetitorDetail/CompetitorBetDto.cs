using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.dtos;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class CompetitorBetDto
    {

        public Guid BetId { get; set; }

        public bool WonBet { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool IsParlay { get; set; }

        public ICollection<BetCompetitorDto> BetCompetitors { get; set; }
    }
}
   