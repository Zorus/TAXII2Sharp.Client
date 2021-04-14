using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TAXII2Sharp_Client.STIX
{
    public class ExternalReference
    {
        [JsonPropertyName("source_name")]
        public String Source_Name { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }
        [JsonPropertyName("url")]
        public String Url { get; set; }
        /* Note: the property type should be its own data type of hashes, however there is not a clean way to implement this 
         * as the structure would be a set of Key-Value pairs where most of the keys are known. You can add in custom values,
         * and because of this I am going for a Dictionary<String, String> at this time. 
         */
        [JsonPropertyName("hashes")]
        public Dictionary<String, String> Hashes { get; set; }
        [JsonPropertyName("external_id")]
        public String External_Id { get; set; }
    }
}
