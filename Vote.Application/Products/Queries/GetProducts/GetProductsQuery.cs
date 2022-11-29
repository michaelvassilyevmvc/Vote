using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;
using Vote.Application.Dtos.Voting;

namespace Vote.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ProductsVm>
    {

    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return new ProductsVm
            {
                Lists = await _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                        .OrderBy(p => p.Name).ToListAsync(cancellationToken)
            };
        }
    }
}
