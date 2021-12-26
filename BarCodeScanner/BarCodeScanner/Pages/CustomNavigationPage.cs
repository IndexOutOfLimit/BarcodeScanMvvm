using Xamarin.Forms;

namespace BarCodeScanner.Pages
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage()
        {
        }

        protected override void OnAppearing()
        {
            //this.BackgroundColor = Color.Black;
            //this.BarBackgroundColor = Color.Black;
            //SetHasNavigationBar(this, true);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
