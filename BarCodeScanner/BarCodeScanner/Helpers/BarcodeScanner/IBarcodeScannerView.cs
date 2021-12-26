/******************************************
 * This code is contributed by Dan Siegel 
******************************************/

using ZXing.Net.Mobile.Forms;

namespace BarCodeScanner.Helpers
{
    internal interface IBarcodeScannerView
    {
        ZXingScannerView ScannerView { get; }

        void DoPush();
        void DoPop();
        string TopText();
        string BottomText();
    }
}