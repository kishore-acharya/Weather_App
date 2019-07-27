using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.Models;

namespace Weather_App.Helpers
{
    public interface ICurrentLocationResolver
    {
        Location GetCurrentLocationAsync();
    }
}
