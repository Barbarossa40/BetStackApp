using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Common;


namespace BetStackApp.Domain.Entities
{
    public class Match : AuditableEntity
    {
        public int MatchId { get; set; }
        public string MatchEventName { get; set; }

        public DateTime MatchDate { get; set; }

        public string Sport { get; set; }

        public string League { get; set; }

        //add later once basic functions are operational
        //public List<Competitor> MatchCompetitors { get; set; }

        //public Competitor Winner { get; set; }

    }
}
