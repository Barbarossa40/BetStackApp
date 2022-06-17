using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetList
{
    public class GetBetListQueryHandler : IRequestHandler<GetBetListQuery, List<BetListVm>>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMapper _mapper;
       

        public GetBetListQueryHandler(IMapper mapper, IBetRepository betRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            
        }
        public async Task<List<BetListVm>> Handle(GetBetListQuery request, CancellationToken cancellationToken)
        {
            var allBets = (await _betRepository.GetAllBets(request.IncludeParlayLegs)).OrderByDescending(x => x.DatePlaced); 
            return _mapper.Map<List<BetListVm>>(allBets);



           // remember I need to make sure that when I return the list of bets that Sport,League, and competitors are included.
           // Probs override method in repo implementation. Make sure mappings okay


        }
    }
}


