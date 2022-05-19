using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BetStackApp.Application.Contracts.Persistence;

namespace BetStackApp.Application.Features.Bets.Commands.CreateBet
{
    public class CreateBetCommandValidator : AbstractValidator<CreateBetCommand>
    {
        private readonly IBetRepository _betRepository;
        public CreateBetCommandValidator(IBetRepository betRepository)
        {
            _betRepository = betRepository;


            RuleFor(p => p.MatchBetOn)
                .NotEmpty().WithMessage("{Property} is required.")
                .NotNull();


            RuleFor(p => p.WagerAmount)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .GreaterThan(0);

            RuleFor(p => p.BetOn)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.BetAgainst)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            //RuleFor(b=>b)
            //    .MustAsync(IsBetUnique)

        }

        //private async Task<bool> BetUnique (CreateBetCommand b, CancellationToken token)
        //{
        //    return !(await _betRepository.IsBetUnique();
        //}
    }
}
