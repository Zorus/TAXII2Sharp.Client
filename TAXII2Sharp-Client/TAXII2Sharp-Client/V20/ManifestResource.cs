using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V20
{
    public class ManifestResource
    {
        [JsonPropertyName("objects")]
        public ManifestEntryResource[] Objects { get; set; }
    }
}
