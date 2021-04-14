using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{

    /* TODO: Take this object and make it the base class from which the following classes can inherit:
     *
     *      STIX Domain Object (SDO)
     *      STIX Relationship Object (SRO)
     *      STIX Cyber-Observable Object (SRO)
     *      
     */
    public class STIXObject
    {
        [JsonPropertyName("type")]
        public String Type { get; set; }
        [JsonPropertyName("id")]
        public String Id { get; set; }
        [JsonPropertyName("created_by_ref")]
        public String Created_By_Ref { get; set; }
        [JsonPropertyName("created")]
        public String Created { get; set; }
        [JsonPropertyName("modified")]
        public String Modified { get; set; }
        [JsonPropertyName("revoked")]
        public Boolean Revoked { get; set; }
        [JsonPropertyName("labels")]
        public String[] Labels { get; set; }
        [JsonPropertyName("external_references")]
        public ExternalReference[] External_References{ get; set; }
        [JsonPropertyName("object_marking_refs")]
        public String[] Object_Marking_Refs { get; set; }
        [JsonPropertyName("granular_markings")]
        public GranularMarking[] Granular_Markings { get; set; }

    }
}
