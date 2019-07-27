using System.Threading.Tasks;
using Weather_App.Helpers;
using Weather_App.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using Location = Weather_App.Models.Location;
using System;
using Weather_App.Views;

namespace Weather_App.ViewModels
{
    public class WeatherPageViewModel : BaseViewModel
    {
      
        public WeatherData currentweatherdata = new WeatherData();
       
        public RestService restservice = new RestService();
        
       
        public WeatherPageViewModel()
        {
           
            SetLocationCommand = new Command((SetLocation));
            RefreshCommand = new Command(RefreshMethod);
            NavigateToInfo = new Command(async() => await NavigateToInfoMethod());
            ShowCurrentWeatherAsync();
           
        }

        private async Task<bool> NavigateToInfoMethod()
        {
            await NavigationService.Navigate(new CityInformationPage(),new CityInformationPageViewModel(),true,query);
            return false;
        }

        private void RefreshMethod(object obj)
        {
            //
            
            ShowCurrentWeatherAsync();
            this.query = " ";
            OnPropertyChanged("query");

        }



        //weather elements
        public string IconURL { get; set; }
        public string min_temperature { get; set; }
        public string max_temperature { get; set; }
        public string location { get; set; }
        public string temperature { get; set; }
        public string Location_Label { get; set; } = "No Location";

        //Execution
        public Command SetLocationCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public Command NavigateToInfo { get; set; }
      
        public WeatherData currentweather = new WeatherData();
        public Weather w = new Weather();

        

        public string area { get; set; } = "Please Enter A Location";
        public string query { get; set; }
        public bool IsLoading { get; set; } = false;
        


        public void SetLocation()
        {
            area = query;
            OnPropertyChanged("area");
            GetWeather(this.query);
        }

        public async Task GetWeather(string query)
        {
            IsLoading = true;
            OnPropertyChanged("IsLoading");
            if (!string.IsNullOrWhiteSpace(query))
                currentweather =
                    await restservice.GetWeatherData(GenerateRequestUri(API_Data.OpenWeatherMapEndpoint, query));
            SetWeather();
        }
        public string Description { get; set; }
        public void SetWeather()
        {
            temperature = currentweather.Main.Temperature + "ºC";
            min_temperature = currentweather.Main.TempMin + "ºC";
            max_temperature = currentweather.Main.TempMax + "ºC";
            
            w = currentweather.Weather[0];
            Description = w.Description.ToUpperInvariant();
            var iconcode = w.Icon;
            IconURL= "http://openweathermap.org/img/w/" + iconcode + ".png";

            IsLoading = false;
            OnPropertyChanged("temperature");
            OnPropertyChanged("min_temperature");
            OnPropertyChanged("max_temperature");
            OnPropertyChanged("IsLoading");
            OnPropertyChanged("Description");
            OnPropertyChanged("IconURL");
        }

        private string GenerateRequestUri(string endpoint, string query)
        {
            var requestUri = endpoint;
            requestUri += $"?q={query}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={API_Data.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        public async Task ShowCurrentWeatherAsync()
        {
            
            Location loc = GetCurrentLocation();
            currentweather = await GetWeatherWithLatLonAsync(loc);
            area = await GetCurrentArea(loc);

            SetWeather();
            
            OnPropertyChanged("area");
        }

        private async Task<string> GetCurrentArea(Location loc)
        {
            return await restservice.ResolveAreaAsync(loc);

        }




        public async Task<WeatherData> GetWeatherWithLatLonAsync(Location location)
        {
         
            IsLoading = true;
            OnPropertyChanged("IsLoading");
          
                  currentweather = await restservice.GetWeatherData(GenerateRequestUriWithLatLon(API_Data.OpenWeatherMapEndpoint, location));

                
                

                  if (currentweather != null)
                  {
                      return currentweather;
                  }
                  else
                  {
                      throw (new ArgumentNullException());
                  }
                  

        }

        private string GenerateRequestUriWithLatLon(string endpoint, Location location)
        {
            string lat = location.lat.ToString();
            string lon = location.lon.ToString();
            var requestUri = endpoint;
            requestUri += $"?lat={lat}&lon={lon}";
            requestUri += "&units=metric";
            requestUri += $"&APPID={API_Data.OpenWeatherMapAPIKey}";
            return requestUri;
          
        }

       

        public Location GetCurrentLocation()
        {
            ICurrentLocationResolver resolver = DependencyService.Get<ICurrentLocationResolver>();
            return resolver.GetCurrentLocationAsync();
        }
    }
}