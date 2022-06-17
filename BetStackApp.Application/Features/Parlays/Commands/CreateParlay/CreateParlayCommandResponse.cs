using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Responses;

namespace BetStackApp.Application.Features.Parlays.Commands.CreateParlay
{
    public class CreateParlayCommandResponse: BaseResponse
    {

        public CreateParlayCommandResponse(): base()
        {

        }

        public Guid ParlayId { get; set; }  
    }
}
//right now just returning the ID. May not need the entire response object but we'll see.