using AutoMapper;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<ProductVO, Product>();
                Config.CreateMap<Product, ProductVO>();
            });
            return MappingConfig;
        }

    }
}
