using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor
{
    public class CreateCompetitorDto
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }
    }
}
