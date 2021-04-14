using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{
    class StatementMarking : Marking
    {
        [JsonPropertyName("statement")]
        public String Statement { get; set; }
    }
}
