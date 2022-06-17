using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Domain.Entities;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Features.Matches.Queries.GetMatchDetail;
using BetStackApp.Application.Contracts.Persistence;

namespace BetStackApp.Application.Features.Matches.Queries.GetMatchDetail
{
    public class GetMatchDetailQueryHandler : IRequestHandler<GetMatchDetailQuery, GetMatchDetailVm>
    {
        private readonly IAsyncRepository<Match> _matchRepositiory;
        private readonly IMapper _mapper;

        public GetMatchDetailQueryHandler(IMapper mapper, IAsyncRepository<Match> matchRepositiory)
        {
            _mapper = mapper;
            _matchRepositiory = matchRepositiory;
        }

        public async Task<GetMatchDetailVm> Handle(GetMatchDetailQuery request, CancellationToken cancellationToken)
        {
            var match = await _matchRepositiory.GetByIdAsync(request.MatchId);
            var matchDto = _mapper.Map<GetMatchDetailVm>(match);

            return matchDto;
        }
    }
}
