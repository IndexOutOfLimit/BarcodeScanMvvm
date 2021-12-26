using AutoMapper;

namespace BarCodeScanner.Services.Mappers
{
    public class AutoMapperConfig
    {
        public IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                BarCodeDataMapping.Configure(cfg);                
            });

            var mapper = configuration.CreateMapper();

            return mapper;
        }
    }
}
