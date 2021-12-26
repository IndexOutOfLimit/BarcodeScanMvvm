/******************************************
 * This code is contributed by Dan Siegel 
******************************************/

using System;
using System.Threading.Tasks;
using ZXing;

namespace BarCodeScanner.Helpers
{
    public interface IBarcodeScannerService
    {
        Task<string> ReadBarcodeAsync();

        Task<string> ReadBarcodeAsync(params BarcodeFormat[] barcodeFormats);

        Task<Result> ReadBarcodeResultAsync();

        IObservable<Result> OnBarcodeResult();

        Task<Result> ReadBarcodeResultAsync(params BarcodeFormat[] barcodeFormats);
    }
}