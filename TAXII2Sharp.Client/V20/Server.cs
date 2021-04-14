using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TAXII2Sharp.Client.V20
{
    public class Server : TAXIIClient
    {
        public DiscoveryResource Discovery;

        public Server(String URLBase) : base(URLBase, MIMETypes.TAXII_V20)
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

        public List<APIRoot> GetAPIRoots()
        {
            List<APIRoot> Result = new List<APIRoot>();
            foreach (String element in Discovery.API_Roots)
            {
                Result.Add(new APIRoot(element));
            }

            return Result;
        }
    }
}