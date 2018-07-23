using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;
using Weather_App.Classes;

namespace WeatherMVVM.Core.ViewModels
{
    public class WeatherViewModel : MvxViewModel<Forecast>
    {
        public WeatherViewModel()
        {
        }

        public Forecast Forecast { get; set; }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        public override void Prepare(Forecast parameter)
        {
            Forecast = parameter;
        }

        public string GetLocation()
        {
            return "Weather in " + Forecast.Name + ", " + Forecast.Sys.Country;
        }

        public double GetTemperature()
        {
            return Forecast.Main.Temp;
        }

        public void GetIcon()
        {
            throw new NotImplementedException();
        }

        public string GetDate()
        {
            return "Get at " + DateTime.Now.ToString("dd/MM/yy");
        }

        public double GetWindSpeed()
        {
            return Forecast.Wind.Speed;
        }

        public string GetCloudiness()
        {
            return Forecast.Weather[0].Main;
        }

        public string GetPressure()
        {
            return Forecast.Main.Pressure + "hpa";
        }

        public string GetHumidity()
        {
            return Forecast.Main.Humidity + "%";
        }

        public string GetSunrise()
        {
            return new DateTime(Forecast.Sys.Sunrise).ToString("HH: mm");
        }

        public string GetSunset()
        {
            return new DateTime(Forecast.Sys.Sunset).ToString("HH: mm");
        }

        public string GetCoords()
        {
            return "[" + Forecast.Coord + "]";
        }

        public string GetWindDirection()
        {
            var windDeg = Forecast.Wind.Deg;
            var windDirection = "";

            if (windDeg == 0 || windDeg == 360)
            {
                windDirection = "North";
            }
            else if (windDeg > 0 && windDeg < 45)
            {
                windDirection = "North North-East";
            }
            else if (windDeg == 45)
            {
                windDirection = "North-East";
            }
            else if (windDeg > 45 && windDeg < 90)
            {
                windDirection = "East North-East";
            }
            else if (windDeg == 90)
            {
                windDirection = "East";
            }
            else if (windDeg > 90 && windDeg < 135)
            {
                windDirection = "East South-East";
            }
            else if (windDeg == 135)
            {
                windDirection = "South-East";
            }
            else if (windDeg > 135 && windDeg < 180)
            {
                windDirection = "South South-East";
            }
            else if (windDeg == 180)
            {
                windDirection = "South";
            }
            else if (windDeg > 180 && windDeg < 225)
            {
                windDirection = "South South-West";
            }
            else if (windDeg == 225)
            {
                windDirection = "South-West";
            }
            else if (windDeg > 225 && windDeg < 270)
            {
                windDirection = "West South-West";
            }
            else if (windDeg == 270)
            {
                windDirection = "West";
            }
            else if (windDeg > 270 && windDeg < 315)
            {
                windDirection = "West North-West";
            }
            else if (windDeg == 315)
            {
                windDirection = "North-West";
            }
            else if (windDeg > 315 && windDeg < 360)
            {
                windDirection = "West North-West";
            }
            return windDirection + "(" + windDeg + ")";
        }

        public string GetWindRating()
        {
            var windSpeed = GetWindSpeed();

            var windRating = "";

            if (windSpeed < 0.3)
            {
                windRating = "Calm";
            }
            else if (windSpeed >= 0.3 && windSpeed < 1.6)
            {
                windRating = "Light Air";
            }
            else if (windSpeed >= 1.6 && windSpeed < 3.4)
            {
                windRating = "Light Breeze";
            }
            else if (windSpeed >= 3.4 && windSpeed < 5.6)
            {
                windRating = "Gentle Breeze";
            }
            else if (windSpeed >= 5.5 && windSpeed < 8)
            {
                windRating = "Moderate Breeze";
            }
            else if (windSpeed >= 8 && windSpeed < 10.8)
            {
                windRating = "Fresh Breeze";
            }
            else if (windSpeed >= 10.8 && windSpeed < 13.9)
            {
                windRating = "Strong Breeze";
            }
            else if (windSpeed >= 13.9 && windSpeed < 17.2)
            {
                windRating = "High Wind";
            }
            else if (windSpeed >= 17.2 && windSpeed < 20.8)
            {
                windRating = "Gale";
            }
            else if (windSpeed >= 20.8 && windSpeed < 24.5)
            {
                windRating = "Severe Gale";
            }
            else if (windSpeed >= 24.5 && windSpeed < 28.5)
            {
                windRating = "Storm";
            }
            else if (windSpeed >= 28.5 && windSpeed < 32.7)
            {
                windRating = "Violent Storm";
            }
            else if (windSpeed >= 32.7)
            {
                windRating = "Hurricane Force";
            }
            return windRating;
        }

        public string WindToString()
        {
            return GetWindRating() + " " + GetWindSpeed() + "m/s \n" + GetWindDirection();
        }
    }
}