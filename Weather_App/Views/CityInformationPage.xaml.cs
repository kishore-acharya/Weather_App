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
	public partial class CityInformationPage : ContentPage
	{
       
        public CityInformationPage ()
		{
			InitializeComponent ();
            

        }

        private void InfoView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            ((CityInformationPageViewModel) BindingContext).SetIsLoadingTrue();


        }

        private void InfoView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            ((CityInformationPageViewModel) BindingContext).SetIsLoadingFalse();
        }
    }
}