using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace BarCodeScanner.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            Rg.Plugins.Popup.Popup.Init();

            LoadApplication(new App(new PrismIosPlatformInitializer()));

            bool baseLaunching = base.FinishedLaunching(app, options);
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                if (Window != null)
                    Window.OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;
            }

            return baseLaunching;
        }
    }

    public class PrismIosPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
