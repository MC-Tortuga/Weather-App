using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.Views;
using MvvmCross.Platforms.Android.Views;
using System.Collections.Generic;
using Weather_App.Classes;
using WeatherMVVM.Core.ViewModels;

namespace WeatherMVVM.Droid.Views
{
    [Activity(Label = "WeatherView")]
    public class WeatherView : MvxActivity<WeatherViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.WeatherView);
            var city = FindViewById<TextView>(Resource.Id.city);
            var date = FindViewById<TextView>(Resource.Id.date);
            var temp = FindViewById<TextView>(Resource.Id.temp);
            var visibility = FindViewById<TextView>(Resource.Id.visibility);
            var list = FindViewById<MvxListView>(Resource.Id.listView);

            var fieldName = FindViewById<TextView>(Resource.Id.fieldName);
            var value = FindViewById<TextView>(Resource.Id.value);

            city.Text = ViewModel.GetLocation();
            date.Text = ViewModel.GetDate();
            temp.Text = ViewModel.GetTemperature().ToString();
            visibility.Text = ViewModel.GetCloudiness();

            var _tableItems = new List<ItemDisplay>(); ;
            _tableItems.Add(new ItemDisplay() { fieldName = "Wind", value = ViewModel.WindToString() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Cloudiness", value = ViewModel.GetCloudiness() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Pressure", value = ViewModel.GetPressure() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Humidity", value = ViewModel.GetHumidity() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Sunrise", value = ViewModel.GetSunrise() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Sunset", value = ViewModel.GetSunset() });
            _tableItems.Add(new ItemDisplay() { fieldName = "Geo coords", value = ViewModel.GetCoords() });

            list.ItemTemplateId = Resource.Layout.WeatherTable;
            list.ItemsSource = _tableItems;
        }
    }
}