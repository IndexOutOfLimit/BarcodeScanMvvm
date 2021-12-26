using AutoMapper;
using BarCodeScanner.Models;
using BarCodeScanner.Repository.Entities;

namespace BarCodeScanner.Services.Mappers
{
    public class BarCodeDataMapping
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BarCodeData, BarCodeModel>();
            cfg.CreateMap<BarCodeModel, BarCodeData>();
        }
    }
}
