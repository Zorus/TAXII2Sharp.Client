using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.V21
{
    public class CollectionsResource
    {
        [JsonPropertyName("collections")]
        public CollectionResource[] Collections { get; set; }
    }
}
