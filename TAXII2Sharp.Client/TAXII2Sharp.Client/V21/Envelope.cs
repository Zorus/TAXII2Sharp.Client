using System.Text.Json.Serialization;
using TAXII2Sharp.Client.STIX;

namespace TAXII2Sharp.Client.V21
{
    public class Envelope
    {
        [JsonPropertyName("more")]
        public bool Is_More_Content { get; set; }
        [JsonPropertyName("next")]
        public String NextIndex { get; set; }
        [JsonPropertyName("objects")]
        public STIXObject[] Objects { get; set; }

    }
}
