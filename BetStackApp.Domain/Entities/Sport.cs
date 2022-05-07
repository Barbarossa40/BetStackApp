using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;

namespace BetStackApp.Domain.Entities
{
    public class Sport: AuditableEntity
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }

        public ICollection<Bet>? Bets { get; set; }
        public ICollection<League>? Leagues { get; set; }
    }
}
