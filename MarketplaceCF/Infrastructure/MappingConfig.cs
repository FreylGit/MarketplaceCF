using AutoMapper;
using MarketplaceCF.Models;
using MarketplaceCF.Models.Dto;

namespace MarketplaceCF.Infrastructure
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
