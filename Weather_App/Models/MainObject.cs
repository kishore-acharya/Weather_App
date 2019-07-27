using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Weather_App.Models;

namespace Weather_App.Models
{
    public class MainObject
    {

        public class Address
        {
            public string village { get; set; }
            public string county { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
        }

        public class RootObject
        {
            public string place_id { get; set; }
            public string licence { get; set; }
            public string osm_type { get; set; }
            public string osm_id { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string display_name { get; set; }
            public Address address { get; set; }
            public List<string> boundingbox { get; set; }
        }
    }
}
