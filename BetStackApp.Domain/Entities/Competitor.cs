using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;

namespace BetStackApp.Domain.Entities
{
    public class Competitor : AuditableEntity
    {
        public Guid CompetitorId { get; set; }
        public string Name { get; set; }

        public string Nationality { get; set; }

        public string Notes { get; set; }
       
        public ICollection<BetCompetitor>? CompetitorBets { get; set; }
       
    }
}
