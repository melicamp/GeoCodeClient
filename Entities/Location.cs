using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class Location
    {
        public int Id { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
