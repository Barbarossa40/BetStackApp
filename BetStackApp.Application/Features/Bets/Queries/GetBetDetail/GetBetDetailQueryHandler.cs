using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using AutoMapper;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetailDtos;

namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail
{
    public class GetBetDetailQueryHandler : IRequestHandler<GetBetDetailQuery, BetDetailVM>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IAsyncRepository<Sport> _sportRepository;
        private readonly IAsyncRepository<League> _leagueRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;
        private readonly IAsyncRepository<BetCompetitor> _betCompetitorRepository;
        private readonly IMapper _mapper;

        public GetBetDetailQueryHandler(IMapper mapper, IAsyncRepository<BetCompetitor> betCompetitorRepository, IAsyncRepository<Bet> betRepository, IAsyncRepository<Sport> sportRepository, IAsyncRepository<League> leagueRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            _leagueRepository = leagueRepository;
            _competitorRepository = competitorRepository;
            _betCompetitorRepository = betCompetitorRepository;
        }
        public async Task<BetDetailVM> Handle(GetBetDetailQuery request, CancellationToken cancellationToken)
        {
            var bet = await _betRepository.GetByIdAsync(request.BetId);
            var betDetailDto = _mapper.Map<BetDetailVM>(bet);

            var sport = await _sportRepository.GetByIdAsync(bet.Sport.SportId);
            betDetailDto.Sport = _mapper.Map<GetSportBetDto>(sport);

            var league = await _leagueRepository.GetByIdAsync(bet.League.LeagueId);
            betDetailDto.League = _mapper.Map<GetLeagueBetDto>(league);

            var competitors = await _competitorRepository.GetListByIdAsync(bet.BetId);
            betDetailDto.BetCompetitors = _mapper.Map<List<GetBetCompetitorDto>>(competitors);


            return betDetailDto;
        }

    }
}
