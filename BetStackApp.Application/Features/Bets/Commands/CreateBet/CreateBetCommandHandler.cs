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
        private readonly ILeagueRepository _leagueRepository;

        public CreateBetCommandHandler(IMapper mapper, IBetRepository betRepository, ISportRepository sportRepository, ILeagueRepository leagueRepository)
        {
            _mapper = mapper;
            _betRepository = betRepository;
            _sportRepository = sportRepository;
            
        }
        public async Task<Guid> Handle(CreateBetCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBetCommandValidator();
            var valResult = await validator.ValidateAsync(request);

            if (valResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(valResult);
            }


          var bet = _mapper.Map<Bet>(request);
          bet.Sport = await _sportRepository.GetByIdAsync(bet.SportId);
          bet.League = await _leagueRepository.GetByIdAsync(bet.LeagueId);
          
          // need to figure out how to take in competitors from the form submitt

          //save async needed here
            return bet.BetId;
            // instead of reuting ID you can create a class that returns a reponse
        }
    }
}
