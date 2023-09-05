using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;
using System.Reflection;

namespace KLYDBMS.Application.Converters
{
    public class ManagerTypeToImageConverter : IValueConverter
    {
        private const string ASSETS_RESOURCE = "Assets";

        public static ManagerTypeToImageConverter Instance = new ManagerTypeToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            if (value is string)
            {
                var uri = new Uri((string)value, UriKind.RelativeOrAbsolute);
                var scheme = uri.IsAbsoluteUri ? uri.Scheme : "file";

                switch (scheme)
                {
                    case "file":
                        return new Bitmap(AssetLoader.Open(new Uri((string)$"avares://{assemblyName}/{ASSETS_RESOURCE}/{value}.png")));

                    default:
                        return new Bitmap(AssetLoader.Open(uri));
                }
            }

            return new Bitmap(AssetLoader.Open(new Uri((string)$"avares://{assemblyName}/{ASSETS_RESOURCE}/child-menu.png")));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
