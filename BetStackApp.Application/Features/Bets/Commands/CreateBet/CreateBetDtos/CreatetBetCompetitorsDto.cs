using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet.CreateBetDtos
{
    public class CreatetBetCompetitorsDto
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public bool BetOn { get; set; }
    }
}
