using AutoMapper;
using PaymentsAPI.Data;
using PaymentsAPI.Model;

namespace PaymentsAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<PaymentsVO, Payments>();
                Config.CreateMap<Payments, PaymentsVO>();
            });
            return MappingConfig;
        }
    }
}
