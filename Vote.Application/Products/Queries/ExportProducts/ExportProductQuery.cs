using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vote.Application.Common.Interfaces;

namespace Vote.Application.Products.Queries.ExportProducts
{
    public class ExportProductQuery : IRequest<ExportProductVm>
    {
        public int Id { get; set; }
    }

    public class ExportProductQueryHandler : IRequestHandler<ExportProductQuery, ExportProductVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportProductQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }
        public async Task<ExportProductVm> Handle(ExportProductQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportProductVm();

            var record = await _context.Products
                .Where(x => x.Id == request.Id)
                .ProjectTo<ProductRecord>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            vm.Content = _fileBuilder.BuildProductFile(record);
            vm.ContentType = "text/csv";
            vm.FileName = "Product.csv";

            return await Task.FromResult(vm);
        }
    }
}
