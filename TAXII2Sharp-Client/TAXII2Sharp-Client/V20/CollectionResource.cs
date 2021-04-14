using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V20
{
    /*
     * Reference: https://docs.oasis-open.org/cti/taxii/v2.0/taxii-v2.0.pdf#page=37&zoom=100,92,362
     * 
     * Basic data received about a collection. The ID Attribute can be provided to the Get Collection
     * Endpoint to get the collection.
     * 
     */
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
