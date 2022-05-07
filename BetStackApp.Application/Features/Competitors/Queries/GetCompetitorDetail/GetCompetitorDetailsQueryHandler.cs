using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail.GetCompetitorDetailDtos;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;


namespace BetStackApp.Application.Features.Competitors.Queries.GetCompetitorDetail
{
    public class GetCompetitorDetailsQueryHandler : IRequestHandler<GetCompetitorDetailsQuery,CompetitorDetailsVM>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IBetCompetitorRepository _betCompetitorRepository;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;
        private readonly IMapper _mapper;

        public GetCompetitorDetailsQueryHandler(IMapper mapper, IBetCompetitorRepository betCompetitorRepository, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _betCompetitorRepository = betCompetitorRepository;
            _competitorRepository = competitorRepository;
        }

        public async Task<CompetitorDetailsVM> Handle(GetCompetitorDetailsQuery request, CancellationToken cancellation)
        {
            var competitor = await _competitorRepository.GetByIdAsync(request.CompetitorId);
            var competitorDetailDto = _mapper.Map<CompetitorDetailsVM>(competitor);
            
            var bets = await _betCompetitorRepository.GetAllBetsByCompetitor(competitor.CompetitorId);
            competitorDetailDto.CompetitorBets = _mapper.Map<List<GetCompetitorDetailBetDto>>(bets);
            // this gets bets and maps it to list of betZVm called ^^^^^. I need to figur out if it will implicity take tyhe next step and map the property in GetCompetitorDetailBetDto call bet competitors or if i need to state it here


            return competitorDetailDto;
        }
    }
}


