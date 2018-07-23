using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace WeatherMVVM.Core.Services
{
    public class CacheService : ICacheService
    {
        private static ISettings AppSettings =>
    CrossSettings.Current;

        public string SharedString
        {
            get => AppSettings.GetValueOrDefault(nameof(SharedString), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(SharedString), value);
        }
    }
}