using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.dtos;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class CompetitorDetailsVM
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public SportDto Sport { get; set; }

        public LeagueDto League { get; set; }  
        public ICollection<CompetitorBetDto> BetCompetitor { get; set; }

    }
}

