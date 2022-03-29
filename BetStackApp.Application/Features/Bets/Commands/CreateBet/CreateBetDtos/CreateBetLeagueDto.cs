using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet.CreateBetDtos
{
    public class CreateBetLeagueDto
    {
        public Guid LeagueId { get; set; }
        public string Name { get; set; }

    }
}
