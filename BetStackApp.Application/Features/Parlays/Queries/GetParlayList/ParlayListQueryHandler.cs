using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayList
{
    public class ParlayListQueryHandler : IRequestHandler<ParlayListQuery, List<ParlayListVm>>
    {
        private readonly IParlayRepository _parlayRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Parlay> _asyncRepository;


        public ParlayListQueryHandler(IMapper mapper, IParlayRepository parlayRepository, IAsyncRepository<Parlay> asyncRepository )
        {
            _mapper = mapper;
            _parlayRepository = parlayRepository;
            _asyncRepository=asyncRepository;
        }
        public async Task<List<ParlayListVm>> Handle(ParlayListQuery request, CancellationToken cancellationToken)
        {
            var allParlays = (await _asyncRepository.ListAllAsync()).OrderByDescending(x => x.DateOfCompletion);
            return _mapper.Map<List<ParlayListVm>>(allParlays);




        }
    }
}
