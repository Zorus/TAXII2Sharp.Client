using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.V20
{
    public class ManifestResource
    {
        [JsonPropertyName("objects")]
        public ManifestEntryResource[] Objects { get; set; }
    }
}
