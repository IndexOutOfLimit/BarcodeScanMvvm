using BarCodeScanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarCodeScanner.Services.Contracts
{
    public interface IBarCodeService
    {
        Task<List<BarCodeModel>> GetBarCodes();
        Task<List<BarCodeModel>> SaveBarCode(string barCodeValue);
        Task<List<BarCodeModel>> DeleteBarCodes(List<string> barCodes);
    }
}
