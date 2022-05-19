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
     

        public CreateBetCommandHandler(IMapper mapper, IBetRepository betRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
        }
        public async Task<Guid> Handle(CreateBetCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBetCommandValidator(_betRepository);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var bet = _mapper.Map<Bet>(request);

            bet = await _betRepository.AddAsync(bet);

            return bet.BetId;
  

        }
    }
}
