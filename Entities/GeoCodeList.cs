using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    [JsonObject]
    public class GeoCodeList
    {
        public int Id { get; set; }
        [JsonProperty("results")]
        public IEnumerable<GeoCode> Results { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
