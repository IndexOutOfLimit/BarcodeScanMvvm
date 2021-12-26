using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarCodeScanner.Extensions
{
    public abstract class ValueConverterExtension : BindableObject, IMarkupExtension<IValueConverter>
    {
        public IValueConverter ProvideValue(IServiceProvider serviceProvider)
        {
            return (IValueConverter)this;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ((IMarkupExtension<IValueConverter>)this).ProvideValue(serviceProvider);
        }
    }
}
