using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{
    class TLPMarking : Marking
    {
        [JsonPropertyName("tlp")]
        public String TLP { get; set; }
    }
}
