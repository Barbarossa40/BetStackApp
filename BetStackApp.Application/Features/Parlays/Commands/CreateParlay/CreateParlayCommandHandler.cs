using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Parlays.Commands.CreateParlay
{
    public class CreateParlayCommandHandler: IRequestHandler<CreateParlayCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IParlayRepository _parlayRepository;
        private readonly IBetRepository _betRepository;
        public CreateParlayCommandHandler(IMapper mapper, IParlayRepository parlayRepository, IBetRepository betRepository)
        {
            _mapper = mapper;
            _parlayRepository = parlayRepository;
            _betRepository = betRepository; 
        }

        public async Task<Guid> Handle(CreateParlayCommand request, CancellationToken cancellationToken)
        {
            List<Bet> bets = await _betRepository.GetBetListById(request.ParlayIds);

           
            Parlay newParlay = new Parlay();
            newParlay.ParlayBets= bets;

            newParlay = _mapper.Map<Parlay>(request);

            newParlay = await _parlayRepository.AddAsync(newParlay);

            return newParlay.ParlayId;

            
        }
    }
}
