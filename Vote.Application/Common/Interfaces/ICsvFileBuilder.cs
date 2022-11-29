using System.Collections.Generic;
using Vote.Application.Products.Queries.ExportProducts;

namespace Vote.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductFile(ProductRecord record);
    }
}
