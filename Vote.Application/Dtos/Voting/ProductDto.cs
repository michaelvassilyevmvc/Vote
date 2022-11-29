using AutoMapper;
using Vote.Application.Common.Mappings;
using Vote.Domain.Entities;

namespace Vote.Application.Dtos.Voting
{
    public class ProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(p => p.Category, opt => opt.MapFrom(s => (int)s.Category));
        }

    }
}
