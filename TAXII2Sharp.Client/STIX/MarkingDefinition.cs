using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.STIX
{
    public class MarkingDefinition
    {
        [JsonPropertyName("type")]
        public String Type { get; set; }
        [JsonPropertyName("id")]
        public String Id { get; set; }
        [JsonPropertyName("created_by_ref")]
        public String Created_By_Ref { get; set; }
        [JsonPropertyName("created")]
        public String Created { get; set; }
        [JsonPropertyName("external_references")]
        public ExternalReference[] External_References { get; set; }
        [JsonPropertyName("object_marking_refs")]
        public String[] Object_Marking_Refs { get; set; }
        [JsonPropertyName("granular_marking_refs")]
        public GranularMarking[] Granular_Marking_Refs { get; set; }
        [JsonPropertyName("definition_type")]
        public String Definition_Type { get; set; }
        [JsonPropertyName("definition")]
        public Marking Definition { get; set; }
    }
}
