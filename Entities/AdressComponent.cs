using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class AddressComponent
    {
        public int Id { get; set; }
        [JsonProperty("long_name")]
        public string LongName { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
