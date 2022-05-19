using BetStackApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Domain.Entities
{
    public class Bet : AuditableEntity
    {

        public Bet(Guid betId, Match matchBetOn, double odds, bool winBet, Competitor betOn, Competitor betAgainst, bool isParlayLeg, bool isComplete)
        {
            BetId = betId;
            MatchBetOn = matchBetOn;
            Odds = odds;
            WinBet = winBet;
            BetOn = betOn;
            BetAgainst = betAgainst;
            IsParlayLeg = isParlayLeg;
            IsComplete = isComplete;

        }
        public Bet(Guid betId, Match matchBetOn, double odds, bool winBet, Competitor betOn, Competitor betAgainst, double wagerAmount, double netReturn, bool isParlayLeg, DateOnly datePlaced, bool isComplete)
        {
            BetId = betId;
            MatchBetOn = matchBetOn;
            Odds = odds;
            WinBet = winBet;
            BetOn = betOn;
            BetAgainst = betAgainst;
            WagerAmount = wagerAmount;
            NetReturn = netReturn;
            IsParlayLeg = isParlayLeg;
            DatePlaced = datePlaced;
            IsComplete = isComplete;
        }

        public Guid BetId { get; set; }

        public Match MatchBetOn { get; set; }

        public double Odds { get; set; }

        public bool WinBet { get; set; }

        public Competitor BetOn { get; set; }

        public Competitor BetAgainst { get; set; }
        public bool IsComplete { get; set; }

        public bool IsParlayLeg { get; set; }

        //parlay bets dont need


        public double WagerAmount { get; set; }

        public double NetReturn { get; set; }

        public DateOnly DatePlaced { get; set; }



    }
} 
