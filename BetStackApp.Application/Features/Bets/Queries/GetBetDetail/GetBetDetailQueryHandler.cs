using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using AutoMapper;
using BetStackApp.Application.Features.Bets.Queries.GetBetDetail.GetBetDetailDtos;


namespace BetStackApp.Application.Features.Bets.Queries.GetBetDetail
{
    public class GetBetDetailQueryHandler : IRequestHandler<GetBetDetailQuery, BetDetailVm>
    {
        private readonly IAsyncRepository<Bet> _betRepository;
        private readonly IAsyncRepository<Competitor> _competitorRepository;
        private readonly IAsyncRepository<Match> _matchRepository;
        private readonly IMapper _mapper;

        public GetBetDetailQueryHandler(IMapper mapper, IAsyncRepository<Bet> betRepository, IAsyncRepository<Match> matchRepository, IAsyncRepository<Competitor> competitorRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
            _betRepository = betRepository;
            _competitorRepository = competitorRepository;
         
        }
        public async Task<BetDetailVm> Handle(GetBetDetailQuery request, CancellationToken cancellationToken)
        {
            var bet = await _betRepository.GetByIdAsync(request.BetId);
            var betDetailDto = _mapper.Map<BetDetailVm>(bet);

            return betDetailDto;
        }

    }
}
