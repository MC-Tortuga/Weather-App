using MvvmCross;
using MvvmCross.ViewModels;
using WeatherMVVM.Core.Services;
using WeatherMVVM.Core.ViewModels;

namespace WeatherMVVM.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.LazyConstructAndRegisterSingleton<IWeatherService, WeatherService>();
            Mvx.LazyConstructAndRegisterSingleton<ICacheService, CacheService>();

            RegisterAppStart<CityViewModel>();
        }
    }
}