using CsvHelper;
using System.Globalization;
using System.IO;
using Vote.Application.Common.Interfaces;
using Vote.Application.Products.Queries.ExportProducts;

namespace Vote.Shared.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductFile(ProductRecord record)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecord(record);
            }

            return memoryStream.ToArray();
        }
    }
}
