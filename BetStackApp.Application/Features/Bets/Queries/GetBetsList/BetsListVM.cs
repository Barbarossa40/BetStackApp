using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetailDtos;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetsList
{
    public class BetsListVM
    {
        public Guid BetId { get; set; }

        public Guid SportId { get; set; }
        public GetSportBetDto? Sport { get; set; }

        public Guid LeagueId { get; set; }
        public GetLeagueBetDto? League { get; set; }

        public string? EventName { get; set; }

        public DateTime DateOfBetCompletion { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool WonBet { get; set; }

        public bool ParlayMember { get; set; }

        public ICollection<GetBetCompetitorDto>? BetCompetitors { get; set; }

    }
}
