using AutoMapper;
using BarCodeScanner.Models;
using BarCodeScanner.Repository.Contracts;
using BarCodeScanner.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarCodeScanner.Services
{
    public class BarCodeService : IBarCodeService
    {
        private readonly IMapper _mapper;
        private readonly IBarCodeRepository _barCodeRepository;
        public BarCodeService(IBarCodeRepository barCodeRepository, IMapper mapper)
        {
            _barCodeRepository = barCodeRepository;
            _mapper = mapper;
        }

        public async Task<List<BarCodeModel>> DeleteBarCodes(List<string> barCodes)
        {
            var entities = await _barCodeRepository.DeleteBarCodes(barCodes);

            List<BarCodeModel> records = entities.Select(_mapper.Map<BarCodeModel>).ToList();

            return records;
        }

        public async Task<List<BarCodeModel>> GetBarCodes()
        {
            var entities = await _barCodeRepository.GetBarCodes();

            List<BarCodeModel> records = entities.Select(_mapper.Map<BarCodeModel>).ToList();

            return records;
        }

        public async Task<List<BarCodeModel>> SaveBarCode(string barCodeValue)
        {
            var entities = await _barCodeRepository.SaveBarCode(barCodeValue);

            List<BarCodeModel> records = entities.Select(_mapper.Map<BarCodeModel>).ToList();

            return records;
        }
    }
}
