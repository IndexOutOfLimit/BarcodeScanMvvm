using BarCodeScanner.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarCodeScanner.Repository.Contracts
{
    public interface IBarCodeRepository : IGenericRepository<BarCodeData, int>
    {
        Task<List<BarCodeData>> GetBarCodes();
        Task<List<BarCodeData>> SaveBarCode(string barCodeValue);
        Task<List<BarCodeData>> DeleteBarCodes(List<string> barCodes);
    }
}
