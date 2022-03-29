using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetsList
{
    public class GetBetsListQueryHandler : IRequestHandler<GetBetsListQuery, List<BetsListVM>>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Sport> _sportRepository;  // bring the actaul repo if you want to use repo specific methods
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;

        public GetBetsListQueryHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
        }
        public async Task<List<BetsListVM>> Handle(GetBetsListQuery request, CancellationToken cancellationToken)
        {
            var allBets = (await _betRepository.ListAllAsync()).OrderByDescending(x => x.DateOfBetCompletion); 
            return _mapper.Map<List<BetsListVM>>(allBets);



           // remember I need to make sure that when I return the list of bets that Sport,League, and competitors are included.
           // Probs override method in repo implementation. Make sure mappings okay


        }
    }
}


