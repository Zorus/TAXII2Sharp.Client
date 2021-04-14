using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{
    class KillChainPhase
    {
        [JsonPropertyName("kill_chain_name")]
        public String Kill_Chain_Name { get; set; }
        [JsonPropertyName("phase_name")]
        public String Phase_Name { get; set; }
    }
}
