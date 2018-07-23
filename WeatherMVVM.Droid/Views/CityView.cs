using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using WeatherMVVM.Core.ViewModels;

namespace WeatherMVVM.Droid.Views
{
    [Activity(Label = "CityView", MainLauncher = true)]
    public class CityView : MvxActivity<CityViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CityView);
            var cityTextView = FindViewById<EditText>(Resource.Id.editText);

            var button = FindViewById<Button>(Resource.Id.button);

            var set = this.CreateBindingSet<CityView, CityViewModel>();

            set.Bind(cityTextView).To(vm => vm.City);

            set.Bind(button).To(vm => vm.NavigateCommand);
            set.Apply();
        }
    }
}