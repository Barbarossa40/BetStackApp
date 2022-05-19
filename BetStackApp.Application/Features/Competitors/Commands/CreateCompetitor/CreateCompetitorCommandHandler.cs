using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BetStackApp.Application.Contracts.Persistence;
using BetStackApp.Domain.Entities;

namespace BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor
{
    public  class CreateCompetitorCommandHandler : IRequestHandler<CreateCompetitorCommand, CreateCompetitorCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICompetitorRepository _competitorRepository;
   

        public CreateCompetitorCommandHandler(IMapper mapper, ICompetitorRepository competitorRepository )
        {
            _mapper = mapper;
            _competitorRepository = competitorRepository;

        }

        public async Task<CreateCompetitorCommandResponse> Handle(CreateCompetitorCommand request, CancellationToken cancellationToken)
        {
            var createCompetitorCommandResponse = new CreateCompetitorCommandResponse();

            var validator = new CreateCompetitorCommandValidator(_competitorRepository);
            var valResult = await validator.ValidateAsync(request);

            if (valResult.Errors.Count > 0)
            {
                createCompetitorCommandResponse.Success = false;
                createCompetitorCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in valResult.Errors)
                {
                    createCompetitorCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCompetitorCommandResponse.Success)
            {
                var competitor = new Competitor() { Name = request.Name, HomeBase = request.HomeBase, Description = request.Description };
                competitor = await _competitorRepository.AddAsync(competitor);

                createCompetitorCommandResponse.NewCompetitor = _mapper.Map<CreateCompetitorDto>(competitor);
            }

            return createCompetitorCommandResponse;

        }

    }
}
