using FluentValidation;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 90 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(300).WithMessage("Description must not exceed 120 characters");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category must required.");
        }
    }
}
