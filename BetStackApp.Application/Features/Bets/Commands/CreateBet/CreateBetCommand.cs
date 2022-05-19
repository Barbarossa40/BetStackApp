using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet
{
    public class CreateBetCommand : IRequest<Guid> //this will return ID of newly created bet
    {

        public Match MatchBetOn { get; set; }
        public DateOnly DatePlaced { get; set; }

        public double Odds { get; set; }

        public bool WinBet { get; set; }

        public Competitor BetOn { get; set; }

        public Competitor BetAgainst { get; set; }

        public double WagerAmount { get; set; }

        public double NetReturn { get; set; }

        public bool IsParlayLeg { get; set; }
        public bool IsComplete { get; set; }
    }
}
