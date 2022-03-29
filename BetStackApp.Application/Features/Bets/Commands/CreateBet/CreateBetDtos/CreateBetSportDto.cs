using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet.CreateBetDtos
{
    public class CreateBetSportDto
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }

    }
}
