using BetStackApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Matches.Commands
{
    public class CreateMatchCommandResponse: BaseResponse
    {

        
        
            public CreateMatchCommandResponse() : base()
            {

            }

            public CreateMatchDto NewMatch { get; set; }
        
    }
}
