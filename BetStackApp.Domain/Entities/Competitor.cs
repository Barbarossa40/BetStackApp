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
      
        public string HomeBase { get; set; }

        public string Description { get; set; }

    }
}
