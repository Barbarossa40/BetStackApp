using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail.GetCompetitorDetailDtos
{
    public class GetCompetitorDetailBetDto
    {
        public Guid BetId { get; set; }

        public bool WonBet { get; set; }

        public double WagerAmount { get; set; }
        public double Payout { get; set; }

        public bool IsParlay { get; set; }

        public ICollection<GetCompetitorDetailCompetitorsDto>? BetCompetitors { get; set; }
    }
}
