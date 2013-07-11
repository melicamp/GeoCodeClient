using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class ViewPort
    {
        public int Id { get; set; }
        [JsonProperty("northeast")]
        public Location NorthEast { get; set; }
        [JsonProperty("southwest")]
        public Location SouthWest { get; set; }
    }
}
