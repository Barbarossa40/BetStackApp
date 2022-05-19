using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Matches.Commands
{
    public class CreateMatchCommandHandler: IRequestHandler<CreateMatchCommand, CreateMatchCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;

        public CreateMatchCommandHandler(IMapper mapper, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _matchRepository = matchRepository;
        }

        public async Task<CreateMatchCommandResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var createMatchCommandResponse = new CreateMatchCommandResponse();

            var validator = new CreateMatchCommandValidator(_matchRepository);
            var valResult = await validator.ValidateAsync(request);

            if (valResult.Errors.Count > 0)
            {
                createMatchCommandResponse.Success = false;
                createMatchCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in valResult.Errors)
                {
                    createMatchCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createMatchCommandResponse.Success)
            {
                var match = new Match() { MatchEventName = request.MatchEventName, League = request.League, Sport =request.Sport, MatchDate =request.MatchDate};
                createMatchCommandResponse.NewMatch =_mapper.Map<CreateMatchDto>(match);
            }

            return createMatchCommandResponse;
        }
    }
}
