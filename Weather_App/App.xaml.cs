using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather_App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Weather_App
{
    public partial class App : Application
    {
        public static Page mainPage;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new WeatherPage());
            mainPage = MainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
