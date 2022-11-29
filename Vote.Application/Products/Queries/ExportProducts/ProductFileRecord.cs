using Vote.Application.Common.Mappings;
using Vote.Domain.Entities;

namespace Vote.Application.Products.Queries.ExportProducts
{
    public class ProductRecord : IMapFrom<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
