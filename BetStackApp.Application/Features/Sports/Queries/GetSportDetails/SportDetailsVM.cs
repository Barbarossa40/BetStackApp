using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BetStackApp.Application.Features.Sports.Queries.GetSportDetails
{
    public class SportDetailsVM
    {
        public Guid SportId { get; set; }
        public string? Name { get; set; }
        public ICollection<GetSportDetailsLeagueDto>? Leagues { get; set; }
    }
}
