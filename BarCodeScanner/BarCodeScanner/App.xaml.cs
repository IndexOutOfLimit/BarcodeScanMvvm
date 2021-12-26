using AutoMapper;
using BarCodeScanner.Helpers;
using BarCodeScanner.Resources;
using BarCodeScanner.Pages;
using BarCodeScanner.Repository;
using BarCodeScanner.Repository.Contracts;
using BarCodeScanner.Repository.Entities;
using BarCodeScanner.Services;
using BarCodeScanner.Services.Contracts;
using BarCodeScanner.Services.Mappers;
using BarCodeScanner.ViewModels;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using SQLite;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarCodeScanner
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            AppResources.Culture = CultureInfo.CurrentUICulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            InitializeComponent();

            Uri navigationPath = new Uri("/CustomNavigationPage/MainPage?selectedTab=ScanPage", UriKind.Absolute);
            var navigationResult = await NavigationService.NavigateAsync(navigationPath);
            if (!navigationResult.Success)
                System.Diagnostics.Debug.WriteLine($"Error: {navigationResult.Exception.Message}");

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine(e.Exception);
            };
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // Uses a Popup Page to contain the Scanner
            containerRegistry.Register<IBarcodeScannerService, PopupBarcodeScannerService>();
            containerRegistry.RegisterInstance<IPopupNavigation>(PopupNavigation.Instance);

            // Uses a Content Page to contain the Scanner
            containerRegistry.Register<IBarcodeScannerService, ContentPageBarcodeScannerService>();

            // Pages and ViewModels
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ScanPage, ScanPageViewModel>();

            // AutoMapper
            containerRegistry.RegisterSingleton<IMapper>(() => { return new AutoMapperConfig().GetMapper(); });

            // Services
            containerRegistry.Register<IBarCodeService, BarCodeService>();

            // Repositories
            containerRegistry.Register<IBarCodeRepository, BarCodeRepository>();
        }

        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<SQLiteAsyncConnection>(() =>
            {
                string personalFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                string dbName = AppSettingsManager.Settings["Database:Name"];
                string dbPath = Path.Combine(personalFolderPath, dbName);
                var sqliteConn = new SQLiteAsyncConnection(dbPath);
                sqliteConn.CreateTableAsync<BarCodeData>();
                return sqliteConn;
            });

            // Services

            base.RegisterRequiredTypes(containerRegistry);
        }
    }
}
