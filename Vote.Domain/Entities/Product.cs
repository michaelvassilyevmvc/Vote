using Vote.Domain.Enums;

namespace Vote.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
