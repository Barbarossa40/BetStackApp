using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetList
{
    public class BetListVm  
    {

        public Guid BetId { get; set; }

        public string MatchEventName { get; set; }

        public DateOnly DatePlaced { get; set; }

        public bool IsComplete { get; set; }


        public bool WinBet { get; set; }

        public string BetOn { get; set; }

        public string BetAgainst { get; set; }

        public bool IsParlayLeg { get; set; }


    }
}
