using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class Geometry
    {
        public int Id { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("location_type")]
        public string LocationType { get; set; }
        [JsonProperty("viewport")]
        public ViewPort ViewPort { get; set; }
    }
}
