using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;

namespace BetStackApp.Domain.Entities
{
    public class Parlay : AuditableEntity
    {
        public Guid ParlayId { get; set; }

        public DateTime DateOfCompletion { get; set; }

        public DateTime DatePlaced { get; set; }
        public double AmountWagered { get; set; }

        public bool WinParlay { get; set; }

        public double NetReturn { get; set; }

        public double ParlayOdds { get; set; }

        public ICollection<Bet> ParlayBets { get; set; }
    }
}
