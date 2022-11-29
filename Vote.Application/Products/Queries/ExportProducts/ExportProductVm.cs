namespace Vote.Application.Products.Queries.ExportProducts
{
    public class ExportProductVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
