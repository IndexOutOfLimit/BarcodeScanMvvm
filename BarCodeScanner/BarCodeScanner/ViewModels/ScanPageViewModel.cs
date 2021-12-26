using BarCodeScanner.Helpers;
using BarCodeScanner.Models;
using BarCodeScanner.Services.Contracts;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Linq;
using System.Windows.Input;
using ZXing;

namespace BarCodeScanner.ViewModels
{
    public class ScanPageViewModel : BaseViewModel
    {
        private readonly IBarCodeService _barCodeService;
        private IBarcodeScannerService _barcodeScanner;
        private readonly IPageDialogService _dialogService;

        public ScanPageViewModel(IBarCodeService barCodeService, IBarcodeScannerService barcodeScanner, INavigationService navigationService, IPageDialogService dialogService) 
            : base(navigationService, dialogService)
        {
            _barCodeService = barCodeService;
            _barcodeScanner = barcodeScanner;
            _dialogService = dialogService;

            ScanBarcodeCommand = new DelegateCommand(OnScanBarcodeCommandExecuted);
            DeleteBarcodeCommand = new DelegateCommand(OnDeleteBarcodeCommandExecuted);
            BarCodes = new ObservableRangeCollection<BarCodeModel>();
        }

        private ObservableRangeCollection<BarCodeModel> _barCodes;
        public ObservableRangeCollection<BarCodeModel> BarCodes
        {
            get => _barCodes;
            set => SetProperty(ref _barCodes, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            var records = await _barCodeService.GetBarCodes();
            BarCodes.ReplaceRange(records);

            base.OnNavigatedTo(parameters);
        }

        public ICommand ScanBarcodeCommand { get; private set; }
        public ICommand DeleteBarcodeCommand { get; private set; }

        private async void OnScanBarcodeCommandExecuted()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                // Returns the string value of the Barcode
                string barcodeValue = await _barcodeScanner.ReadBarcodeAsync();

                // Returns the ZXing.NET Barcode Scan Result
                //Result result = await _barcodeScanner.ReadBarcodeResultAsync();
                var records = await _barCodeService.SaveBarCode(barcodeValue);

                BarCodes.ReplaceRange(records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            IsBusy = false;
        }

        private async void OnDeleteBarcodeCommandExecuted()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;

                var selectedBarCodeObjects = BarCodes.Where(l => l.IsSelected).ToList();

                if(selectedBarCodeObjects.Count==0)
                {
                    await _dialogService.DisplayAlertAsync("Info", "Please select item to delete.", "Ok");
                    return;
                }

                var selectedBarCodes = selectedBarCodeObjects.Select(x => x.BarCodeValue).ToList();

                var records = await _barCodeService.DeleteBarCodes(selectedBarCodes);

                BarCodes.ReplaceRange(records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            IsBusy = false;
        }
    }
}
