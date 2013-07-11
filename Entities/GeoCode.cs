using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoCodeClient
{
    public class GeoCode
    {
        public int Id { get; set; }
        [JsonProperty("address_components")]
        public List<AddressComponent> Addresses { get; set; }
        [JsonProperty("formatted_address")]
        public string FormatedAddress { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
        [JsonProperty("partial_match")]
        public bool PartialMatch { get; set; }
    }
}
