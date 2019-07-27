using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather_App.Models;

namespace Weather_App.Helpers
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some Exeception occurd in geting the data");
            }

            return weatherData;
        }

        public  async Task<string> ResolveAreaAsync(Location loc)
        {

           


            HttpClient client = new HttpClient();
            MainObject.RootObject areaobj = new MainObject.RootObject();

            try
            {
                var response = await client.GetAsync(
                     "https://us1.locationiq.org/v1/reverse.php?&key="+Models.API_Data.ReverseGeoCodingAPIKey+"&lat=" + loc.lat + "&lon=" + loc.lon + "12&format=json");

                string content = await response.Content.ReadAsStringAsync();
                areaobj = JsonConvert.DeserializeObject<MainObject.RootObject>(content);
                string[] str = areaobj.display_name.Split(',');
                return str[0]+str[1] ;
           
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.ToString());
                return "Not Able to resolve ";
            }

          
                     
        }
    }
}
