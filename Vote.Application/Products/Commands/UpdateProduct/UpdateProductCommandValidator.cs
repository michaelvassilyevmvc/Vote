using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 90 characters");
            RuleFor(v => v.Description)
                .MaximumLength(200).WithMessage("Description must not exceed 120 characters.");
            RuleFor(v => v.Category)
                .NotEmpty().WithMessage("Category is required!");

        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Products.AllAsync(p => p.Name != name);
        }


    }
}
