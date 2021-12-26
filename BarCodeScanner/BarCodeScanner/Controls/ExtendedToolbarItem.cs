//using System.Collections.Generic;
//using Xamarin.Essentials;
//using Xamarin.Forms;

//namespace BarCodeScanner.Controls
//{
//    public class ExtendedToolbarItem : ToolbarItem
//    {
//        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(ExtendedToolbarItem), true, BindingMode.TwoWay, propertyChanged: OnIsVisibleChanged);

//        public bool IsVisible
//        {
//            get => (bool)GetValue(IsVisibleProperty);
//            set => SetValue(IsVisibleProperty, value);
//        }

//        private static void OnIsVisibleChanged(BindableObject bindable, object oldvalue, object newvalue)
//        {
//            var item = bindable as ExtendedToolbarItem;

//            if (item == null || item.Parent == null)
//                return;

//            IList<ToolbarItem> toolbarItems = ((ContentPage)item.Parent).ToolbarItems;
//            bool showShow = (bool)newvalue;

//            if (showShow && !toolbarItems.Contains(item))
//            {
//                MainThread.BeginInvokeOnMainThread(() =>
//                {
//                    toolbarItems.Add(item);
//                });
//            }
//            else if (!showShow && toolbarItems.Contains(item))
//            {
//                MainThread.BeginInvokeOnMainThread(() =>
//                {
//                    toolbarItems.Remove(item);
//                });
//            }
//        }
//    }
//}
