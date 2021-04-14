using System;
using System.Text.Json.Serialization;

namespace TAXII2Sharp.Client.V20
{
    public class APIRootResource
    {
        [JsonPropertyName("title")]
        public String Title { get; set; }
        [JsonPropertyName("description")]
        public String Description { get; set; }
        [JsonPropertyName("versions")]
        public String[] Versions { get; set; }
        /* Note that though the documentation says this data type is an integer, the data type received from endpoints during testing is of type String but can be parsed to integer.
         * As such, leaving this as a String data type for now
         * Reference: https://docs.oasis-open.org/cti/taxii/v2.0/taxii-v2.0.pdf#page=29&zoom=100,92,278
         */
        [JsonPropertyName("max_content_length")]
        public String Max_Content_Length { get; set; }
    }
}
