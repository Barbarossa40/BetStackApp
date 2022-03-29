using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Sports.Queries.GetSportsList
{
    public class GetSportsListQueryHandler : IRequestHandler<GetSportsListQuery,List<SportsListVM>>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;


        public GetSportsListQueryHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
        }
        public async Task<List<SportsListVM>> Handle(GetSportsListQuery request, CancellationToken cancellationToken)
        {
            var allSports = (await _sportRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<SportsListVM>>(allSports);
        }
    }
}
