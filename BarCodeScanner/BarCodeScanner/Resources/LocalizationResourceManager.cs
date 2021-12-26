using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace BarCodeScanner.Resources
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private ResourceManager resourceManager;
        private static readonly Lazy<LocalizationResourceManager> currentHolder = new Lazy<LocalizationResourceManager>(() => new LocalizationResourceManager());

        public static LocalizationResourceManager Current => currentHolder.Value;
        public event PropertyChangedEventHandler PropertyChanged;


        public void Init(ResourceManager resource)
        {
            resourceManager = resource;
        }

        public void Init(ResourceManager resource, CultureInfo initialCulture)
        {
            CurrentCulture = initialCulture;
            Init(resource);
        }


        public string GetValue(string text)
        {
            if (resourceManager == null)
                throw new InvalidOperationException($"Must call {nameof(LocalizationResourceManager)}.{nameof(Init)} first");

            return resourceManager.GetString(text, CurrentCulture) ?? throw new NullReferenceException($"{nameof(text)}: {text} not found");
        }

        public string this[string text] => GetValue(text);

        private CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
        public CultureInfo CurrentCulture
        {
            get => currentCulture;
            set
            {
                currentCulture = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }
    }
}
