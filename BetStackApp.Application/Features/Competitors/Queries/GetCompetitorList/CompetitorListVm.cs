using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorList
{
    public class CompetitorListVm
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public string Nationality { get; set; }



    }
}
