using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Bets.Commands.DeleteBet
{
    public class DeleteBetCommand : IRequest
    {
        public Guid BetId { get; set; } 
    }
}
