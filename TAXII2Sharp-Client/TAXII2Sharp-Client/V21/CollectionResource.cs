using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V21
{
    public class CollectionResource
    {
        [JsonPropertyName("id")]
        public String Id { get; set; }
        [JsonPropertyName("title")]
        public String Title { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }
        [JsonPropertyName("can_read")]
        public bool Can_Read { get; set; }
        [JsonPropertyName("can_write")]
        public bool Can_Write { get; set; }
        [JsonPropertyName("media_types")]
        public String[] Media_Types { get; set; }
    }
}
