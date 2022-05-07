using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetailDtos
{
    public class GetLeagueBetDto
    {
        public Guid LeagueId { get; set; }
        public string Name { get; set; }
//        public Guid SportId { get; set; } not needed?
    }
}
