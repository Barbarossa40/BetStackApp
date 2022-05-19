using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using BetStackApp.Application.Contracts.Persistence;

namespace BetStackApp.Application.Features.Competitors.Commands.CreateCompetitor
{
    public class CreateCompetitorCommandValidator : AbstractValidator<CreateCompetitorCommand>
    {
        private readonly ICompetitorRepository _competitorRepository;

       public CreateCompetitorCommandValidator(ICompetitorRepository competitorRepository)
       {
            _competitorRepository = competitorRepository;
            
        RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Property} is required.")
                .NotNull();

            RuleFor(c => c)
           .MustAsync(CompetitorNameAndHomeBaseUnique)
           .WithMessage("An match with the same name and date already exists.");
        }
        private async Task<bool> CompetitorNameAndHomeBaseUnique(CreateCompetitorCommand c, CancellationToken token)
        {
            return !(await _competitorRepository.AreCompetitorNameAndHomeBaseUnique(c.Name, c.HomeBase));
        }
    }
}
