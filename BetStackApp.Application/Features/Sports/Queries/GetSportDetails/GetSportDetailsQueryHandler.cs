using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;
using MediatR;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail;

namespace BetStackApp.Application.Features.Sports.Queries.GetSportDetails
{
    public class GetSportDetailsQueryHandler: IRequestHandler<GetSportDetailsQuery,SportDetailsVM>
    {

        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;

        public GetSportDetailsQueryHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
        }

        public async Task<SportDetailsVM> Handle(GetSportDetailsQuery request, CancellationToken cancellation)
        {
            var sport = (await _sportRepository.GetByIdAsync(request.SportId));
            var sportDto = _mapper.Map<SportDetailsVM>(sport);

            var league = await _leagueRepository.GetListByIdAsync(sport.SportId); // need method in league repo to get league by sportID
            sportDto.Leagues =_mapper.Map<List<GetSportDetailsLeagueDto>>(league);


            return sportDto;
        }

    }
}
