using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;
using AutoMapper;




namespace BetStackApp.Application.Features.Bets.Commands.CreateBet
{
    public class CreateBetCommandHandler : IRequestHandler<CreateBetCommand,Guid>    
    {
        private readonly IBetRepository _betRepository;
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public CreateBetCommandHandler(IMapper mapper, IBetRepository betRepository, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            
        }
        public async Task<Guid> Handle(CreateBetCommand request, CancellationToken cancellationToken)
        {
            request.Sport = await _sportRepository.GetByIdAsync
            
        }
    }
}
