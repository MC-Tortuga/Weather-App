using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using Weather_App.Classes;
using WeatherMVVM.Core.Services;

namespace WeatherMVVM.Core.ViewModels
{
    public class CityViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ICacheService _cacheService;
        private readonly IWeatherService _weatherService;
        private string _city;

        public CityViewModel(IWeatherService weatherService, ICacheService cacheService, IMvxNavigationService navigationService)
        {
            _weatherService = weatherService;
            _cacheService = cacheService;
            _navigationService = navigationService;

            NavigateCommand = new MvxAsyncCommand(DoNavigate);
        }

        private async Task DoNavigate()
        {
            Forecast = await _weatherService.GetForecastRequest(City);

            await _navigationService.Navigate<WeatherViewModel, Forecast>(Forecast);
        }

        public string City
        {
            get => _city;
            set
            {
                SetProperty(ref _city, value);
            }
        }

        public Forecast Forecast { get; set; }

        public IMvxAsyncCommand NavigateCommand { get; private set; }

        public override async Task Initialize()
        {
            await base.Initialize();

            //Console.WriteLine(Forecast);
        }
    }
}