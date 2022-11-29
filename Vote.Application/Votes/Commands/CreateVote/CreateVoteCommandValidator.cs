using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Votes.Commands.CreateVote
{
    public class CreateVoteCommandValidator: AbstractValidator<CreateVoteCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateVoteCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("ProductID is required.");
            RuleFor(x => x.PersonId)
                .NotNull().WithMessage("PersonID is required.");
        }
    }
}
