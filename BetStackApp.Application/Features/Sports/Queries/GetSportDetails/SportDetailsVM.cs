using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Features.Bets.dtos;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;


namespace BetStackApp.Application.Features.Sports.Queries.GetSportDetails
{
    public class SportDetailsVM
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }

        public ICollection<CompetitorBetDto> Bets { get; set; }
        public ICollection<LeagueDto> Leagues { get; set; }
    }
}
