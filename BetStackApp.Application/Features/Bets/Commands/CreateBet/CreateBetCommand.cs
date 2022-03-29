using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Features.Bets.Commands.CreateBet.CreateBetDtos;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet
{
    public class CreateBetCommand : IRequest<Guid> //this will return ID of newly creatred bet
    {

        public Guid BetId { get; set; }
        public Guid UserId { get; set; }

        public CreateBetSportDto Sport { get; set; }

        public CreateBetLeagueDto League { get; set; }

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

        public ICollection<CreatetBetCompetitorsDto> BetCompetitors { get; set; }
    }
}
