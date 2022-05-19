using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Responses;


namespace BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor
{
    public class CreateCompetitorCommandResponse : BaseResponse
    {
        public CreateCompetitorCommandResponse() : base()
        {

        }

        public CreateCompetitorDto NewCompetitor { get; set; } 
    }
}
