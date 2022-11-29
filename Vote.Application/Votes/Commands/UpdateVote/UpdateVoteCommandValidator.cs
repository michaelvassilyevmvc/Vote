using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Votes.Commands.UpdateVote
{
    public class UpdateVoteCommandValidator: AbstractValidator<UpdateVoteCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVoteCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("ProductID is required");

            RuleFor(x => x.PersonId)
                .NotNull().WithMessage("PersonID is required");
        }
    }
}
