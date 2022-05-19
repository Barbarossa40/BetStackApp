using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail
{
    public class ParlayDetailVm
    {

        public Guid ParlayId { get; set; }

        public DateOnly DateOfCompletion { get; set; }

        public DateOnly DatePlaced { get; set; }
        public double AmountWagered { get; set; }

        public bool WinParlay { get; set; }

        public double NetReturn { get; set; }

        public double ParlayOdds { get; set; }

        public ICollection<BetDto> ParlayBets { get; set; }
    }
}
