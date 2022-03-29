using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;

namespace BetStackApp.Domain.Entities
{
    public class Parlay
    {
        public Guid ParlayId { get; set; }

        public ICollection<Bet> ParlayMember { get; set; }
    }
}
