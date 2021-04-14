using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.STIX
{
    public class Relationship
    {
        [JsonPropertyName("created_by_ref")]
        public String Created_By_Ref { get; set; }
        [JsonPropertyName("object_marking_refs")]
        public MarkingDefinition Object_Marking_Refs { get; set; }
    }
}
