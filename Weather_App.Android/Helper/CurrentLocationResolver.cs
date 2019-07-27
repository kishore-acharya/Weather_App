using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_App.Droid.Helper;
using Weather_App.Helpers;
using Weather_App.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using Location = Weather_App.Models.Location;

[assembly: Dependency(typeof(CurrentLocationResolver))]
namespace Weather_App.Droid.Helper
{
    public class CurrentLocationResolver : ICurrentLocationResolver
    {
        public Location GetCurrentLocationAsync()

        {
            Models.Location CurrentLocation = new Models.Location();
            GetLocationFromSystem(CurrentLocation);
            

            return CurrentLocation;
        }

        public async Task<Models.Location> GetLocationFromSystem(Models.Location CurrentLocation)
        {
            Xamarin.Essentials.Location Loc = await Geolocation.GetLastKnownLocationAsync();


            CurrentLocation.lat = Loc.Latitude;
            CurrentLocation.lon = Loc.Longitude;
            return CurrentLocation;
        }

       
    }
}