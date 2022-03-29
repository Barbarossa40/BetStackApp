using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;
using BetStackApp.Application.Features.Bets.dtos;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorsList
{
    public class CompetitorsListVM
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public SportDto Sport { get; set; }

        public LeagueDto League { get; set; }


    }
}
