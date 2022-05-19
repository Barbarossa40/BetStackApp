using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetStackApp.Application.Contracts.Persistence;
using FluentValidation;

namespace BetStackApp.Application.Features.Matches.Commands
{
    public class CreateMatchCommandValidator: AbstractValidator<CreateMatchCommand>
    {
        private readonly IMatchRepository _matchRepository;
        public CreateMatchCommandValidator(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;

            RuleFor(p => p.MatchEventName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(m => m)
                .MustAsync(MatchNameAndDateUnique)
                .WithMessage("An match with the same name and date already exists.");

        }

        private async Task<bool> MatchNameAndDateUnique(CreateMatchCommand m, CancellationToken token)
        {
            return !(await _matchRepository.AreMatchNameAndDateUnique(m.MatchEventName, m.MatchDate));
        }
    }
}

