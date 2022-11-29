using System.Collections.Generic;
using Vote.Application.Dtos.Voting;

namespace Vote.Application.Products.Queries.GetProducts
{
    public class ProductsVm
    {
        public IList<ProductDto> Lists { get; set; }

    }
}
