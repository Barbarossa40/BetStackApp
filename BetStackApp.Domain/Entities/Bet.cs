using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;

namespace BetStackApp.Domain.Entities
{
    public class Bet: AuditableEntity
    {
        public Guid BetId { get; set; }
        public Guid UserId { get; set; }

        public Guid SportId { get; set; }
        public Sport? Sport { get; set; }

        public Guid LeagueId { get; set; }
        public League? League { get; set; }

        public DateTime DatePlaced { get; set; }

        public string? BetEventName { get; set; }

        public DateTime DateOfBetCompletion { get; set; }

        public int Odds { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool WonBet { get; set; }

        public bool EarlyCashOut { get; set; }

        public double EarlyCashoutAmount { get; set; }

        public bool ParlayMember { get; set; }

        public ICollection<BetCompetitor>? BetCompetitors { get; set; }
       
    }
}
