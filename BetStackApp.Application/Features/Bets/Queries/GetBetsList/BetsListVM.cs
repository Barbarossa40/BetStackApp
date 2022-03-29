using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.dtos;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetsList
{
    public class BetsListVM
    {
        public Guid BetId { get; set; }

        public SportDto SportGroup { get; set; }

        public LeagueDto League { get; set; }

        public string BetEventName { get; set; }

        public DateTime DateOfBetCompletion { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool WonBet { get; set; }

        public ICollection<BetCompetitorDto> BetCompetitors { get; set; }

    }
}
