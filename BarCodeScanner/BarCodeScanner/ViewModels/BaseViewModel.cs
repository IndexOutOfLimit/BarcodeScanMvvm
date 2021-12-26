using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace BarCodeScanner.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware, IDestructible
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService DialogService { get; private set; }

        public BaseViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void Destroy() { }
    }
}
