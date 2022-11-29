using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;
using Vote.Domain.Enums;

namespace Vote.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                Category = request.Category
            };
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
