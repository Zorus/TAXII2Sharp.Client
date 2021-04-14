using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V21
{
    public class ManifestRecordResource
    {
        [JsonPropertyName("id")]
        public String Id { get; set; }
        [JsonPropertyName("date_added")]
        public String Date_Added { get; set; }
        [JsonPropertyName("versions")]
        public String[] Versions { get; set; }
        [JsonPropertyName("media_types")]
        public String Media_Types { get; set; }
    }
}
