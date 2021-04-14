using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{
    public class Bundle
    {
        [JsonPropertyName("type")]
        public String Type { get; set; }
        [JsonPropertyName("id")]
        public String Id { get; set; }
        [JsonPropertyName("spec_version")]
        public String Spec_Version { get; set; }
        [JsonPropertyName("objects")]
        public STIXObject[] Objects { get; set; }
    }
}
