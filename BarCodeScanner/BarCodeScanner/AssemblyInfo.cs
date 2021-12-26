using BarCodeScanner.Resources;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

#if DEBUG
[assembly: XamlCompilation(XamlCompilationOptions.Skip)]
#else
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
#endif

[assembly: NeutralResourcesLanguage("en-US")]

[assembly: ExportFont("fa-regular-400.ttf", Alias = FontAwesomeFontFamily.Regular)]
[assembly: ExportFont("fa-solid-900.ttf", Alias = FontAwesomeFontFamily.Solid)]
[assembly: ExportFont("fa-brands-400.ttf", Alias = FontAwesomeFontFamily.Brands)]
