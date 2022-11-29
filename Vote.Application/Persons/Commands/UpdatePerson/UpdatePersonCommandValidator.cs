using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator: AbstractValidator<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 90 characters");
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Age is required")
                .GreaterThanOrEqualTo(18).WithMessage("Must be greater or equal 18");
        }
    }
}
