using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Sports.Queries.GetSportDetails
{
    public class GetSportDetailsQuery : IRequest<SportDetailsVM>
    {
        public Guid SportId { get; set; }
    }
}
