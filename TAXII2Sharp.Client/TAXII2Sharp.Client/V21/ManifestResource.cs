using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.V21
{
    class ManifestResource
    {
        [JsonPropertyName("more")]
        public bool Is_More_Content { get; set; }
        [JsonPropertyName("objects")]
        public ManifestRecordResource[] objects { get; set; }
    }
}
