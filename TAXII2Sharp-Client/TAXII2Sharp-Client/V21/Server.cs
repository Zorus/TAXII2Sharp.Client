using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static TAXII2Sharp_Client.Common;

namespace TAXII2Sharp_Client.V21
{
    public class Server : TAXIIClient
    {
        public Server(String URLBase) : base(URLBase, Common.MEDIA_TYPE_TAXII_V21)
        {
            BasePath = URLBase;
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true
            };

            Discovery = JsonSerializer.Deserialize<DiscoveryResource>(GetDiscovery(), options);
        }



        public String GetDiscovery()
        {
            return GetStringResponse("");
        }

        public String GetStringValue(String URI)
        {
            return GetStringResponse(URI);
        }

        public DiscoveryResource Discovery;

    }
}
