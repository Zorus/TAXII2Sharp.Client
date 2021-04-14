using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V21
{
    public class DiscoveryResource
    {
        [JsonPropertyName("title")]
        public String Title { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }
        [JsonPropertyName("contact")]
        public String Contact { get; set; }
        [JsonPropertyName("default")]
        public String Default { get; set; }
        [JsonPropertyName("api_roots")]
        public String[] API_Roots { get; set; }
    }
}
