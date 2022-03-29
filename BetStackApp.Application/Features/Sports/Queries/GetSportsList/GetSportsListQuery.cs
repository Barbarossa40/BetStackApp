using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BetStackApp.Application.Features.Sports.Queries.GetSportsList
{
    public class GetSportsListQuery : IRequest<List<SportsListVM>>
    {
    }
}
