using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V21
{
    class ManifestResource
    {
        [JsonPropertyName("more")]
        public bool More { get; set; }
        [JsonPropertyName("objects")]
        public ManifestRecordResource[] objects { get; set; }
    }
}
