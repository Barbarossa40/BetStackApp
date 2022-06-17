using BetStackApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet
{
    public class CreateBetCommandResponse: BaseResponse
    {
        public CreateBetCommandResponse(): base()
        {

        }

        public CreateBetDto NewBet { get; set; }
    }
}
//not in use jsut returning ID at the moment