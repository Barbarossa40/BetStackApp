using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Leagues.Queries.GetLeaguesList
{
    public class LeaguesListVM
    {
        public Guid LeagueId { get; set; }
        public string Name { get; set; }

        public Guid SportId { get; set; }


    }
}
