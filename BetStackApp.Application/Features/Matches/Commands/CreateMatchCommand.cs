using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Matches.Commands
{
    public class CreateMatchCommand: IRequest<CreateMatchCommandResponse>
    {

        public string MatchEventName { get; set; }

        public DateTime MatchDate { get; set; }

        public string Sport { get; set; }

        public string League { get; set; }
    }
}
