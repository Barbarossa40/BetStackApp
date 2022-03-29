using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Leagues.Queries.GetLeaguesList
{
    public class GetLeaguesListQueryHandler : IRequestHandler<GetLeaguesListQuery, List<LeaguesListVM>>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;


        public GetLeaguesListQueryHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
        }

        public async Task<List<LeaguesListVM>> Handle(GetLeaguesListQuery request, CancellationToken cancellationToken)
        {
            var allLeagues = (await _competitorRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<LeaguesListVM>>(allLeagues);
        }


    }

}
