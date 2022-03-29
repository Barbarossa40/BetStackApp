using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.dtos;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail
{
    public class BetDetailVM
    {
        public Guid BetId { get; set; }
        public Guid UserId { get; set; }

        public SportDto Sport { get; set; }

        public LeagueDto League { get; set; }

        public DateTime DatePlaced { get; set; }

        public string BetEventName { get; set; }

        public DateTime DateOfBetCompletion { get; set; }

        public int WagerOdds { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool WonBet { get; set; }

        public bool EarlyCashOut { get; set; }

        public double EarlyCashoutAmount { get; set; }

        public bool IsParlay { get; set; }

        public ICollection<BetCompetitorDto> BetCompetitors { get; set; }
     
    }
}
