using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.STIX
{
    class StatementMarking : Marking
    {
        [JsonPropertyName("statement")]
        public String Statement { get; set; }
    }
}
