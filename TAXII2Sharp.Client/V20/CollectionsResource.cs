using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.V20
{
    public class CollectionsResource
    {
        [JsonPropertyName("collections")]
        public CollectionResource[] Collections { get; set; }
    }
}
