using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using AutoMapper;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Parlays.Queries.GetParlayDetail
{
    public class GetParlayDetailQueryHandler: IRequestHandler<GetParlayDetailQuery, ParlayDetailVm>
    {
        private readonly IParlayRepository _parlayRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Parlay> _asyncRepository;


        public GetParlayDetailQueryHandler(IMapper mapper, IParlayRepository parlayRepository, IAsyncRepository<Parlay> asyncRepository)
        {
            _mapper = mapper;
            _parlayRepository = parlayRepository;
            _asyncRepository = asyncRepository;
        }

        public async Task<ParlayDetailVm> Handle(GetParlayDetailQuery request, CancellationToken cancellationToken)
        {
            var parlay = (await _asyncRepository.GetByIdAsync(request.ParlayId));
           
            return _mapper.Map<ParlayDetailVm>(parlay);




        }
    }
}
