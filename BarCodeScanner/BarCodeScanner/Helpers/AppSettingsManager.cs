using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace BarCodeScanner.Helpers
{
    public class AppSettingsManager
    {
        private static AppSettingsManager _instance;
        private readonly JObject _secrets;

        private const string Namespace = "BarCodeScanner";
        private const string FileName = "appsettings.json";

        private AppSettingsManager()
        {
            try
            {
                var assembly = Assembly.Load("BarCodeScanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                var stream = assembly.GetManifestResourceStream($"{Namespace}.{FileName}");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    _secrets = JObject.Parse(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to load secrets file.");
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        public static AppSettingsManager Settings
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppSettingsManager();
                }

                return _instance;
            }
        }

        public string this[string name]
        {
            get
            {
                string returnValue = "";

                try
                {
                    var path = name.Split(':');

                    JToken node = _secrets[path[0]];
                    for (int index = 1; index < path.Length; index++)
                    {
                        node = node[path[index]];
                    }

                    returnValue = node.ToString();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to retrieve secret '{name}'");
                    Debug.WriteLine($"Error: {ex.Message}");
                }

                return returnValue;
            }
        }
    }
}
