using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather_App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new WeatherPageViewModel();
            
		}
	}
}