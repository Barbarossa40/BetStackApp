using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;


namespace BetStackApp.Domain.Entities
{
    public class BetCompetitor
    {
        public Guid BetId { get; set; }

        public Bet? Bet { get; set; }

        public Guid CompetitorId { get; set; }

        public Competitor? Competitor { get; set; }

        public bool BetOn { get; set; }
    }
}
