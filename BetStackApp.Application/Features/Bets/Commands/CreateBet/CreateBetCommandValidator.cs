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
        public CreateBetCommandValidator()//(IBetRepository betRepository)
        {   
           //_betRepository = betRepository;


            RuleFor(p => p.BetEventName)
                .NotEmpty().WithMessage("{Property} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WagerAmount)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .GreaterThan(0);

            RuleFor(p => p.BetCompetitors)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

              
            //private async Task<bool> BetDateComboUnique(CreateBetCommand command, CancellationToken cancellationToken)
            //{
            // cant use bet event name. need to makje sure no combo of bet and CompoID duplicated

            //}

        }

    }
}
//public Guid UserId { get; set; }

//public Guid SportId { get; set; }

//public Guid LeagueId { get; set; }

//public DateTime DatePlaced { get; set; }

//public string BetEventName { get; set; }

//public DateTime DateOfBetCompletion { get; set; }

//public int WagerOdds { get; set; }

//public double WagerAmount { get; set; }

//public double Payout { get; set; }

//public bool WonBet { get; set; }

//public bool EarlyCashOut { get; set; }

//public double EarlyCashoutAmount { get; set; }

//public bool IsParlay { get; set; }

//public ICollection<CreatetBetCompetitorsDto> BetCompetitors { get; set; } /// not sure how to transerfer competitor object or how to add who won