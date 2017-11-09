using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAZip.Models
{
    public class CityInfo
    {
        public CityInfo(string name, string state, string zip, string longitude, string latitude)
        {
            this.Name = name;
            this.State = state;
            this.Zip = zip;
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public string Name { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
    }
}
