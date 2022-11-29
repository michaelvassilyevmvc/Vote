using FluentValidation;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 90 characters");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Age is required.")
                .GreaterThanOrEqualTo(18).WithMessage("Age must be greate or equal 18");

        }


    }
}
