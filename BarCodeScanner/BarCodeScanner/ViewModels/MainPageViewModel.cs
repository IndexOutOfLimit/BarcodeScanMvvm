using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;

namespace BarCodeScanner.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {       
        private bool _IsInternetAvailable;
        public bool IsInternetAvailable
        {
            get => _IsInternetAvailable;
            set => SetProperty(ref _IsInternetAvailable, value);
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            IsInternetAvailable = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsInternetAvailable = e.NetworkAccess == NetworkAccess.Internet;
        }

        public override void Destroy()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;

            base.Destroy();
        }
    }
}
