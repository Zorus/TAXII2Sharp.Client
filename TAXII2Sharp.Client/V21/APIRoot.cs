using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TAXII2Sharp.Client.V21
{
    public class APIRoot : TAXIIClient
    {
        public APIRootResource Resource { get; set; }

        public List<Collection> Collections { get; set; } = new List<Collection>();

        public String BaseServer { get; set; }

        public APIRoot(String URI) : base(URI, MIMETypes.TAXII_V21)
        {
            BaseServer = URI;
            Resource = JsonSerializer.Deserialize<APIRootResource>(GetBase());
            GetCollections();

        }

        public String GetBase()
        {
            return GetStringResponse("");
        }

        public String GetStatus(String StatusID)
        {
            return GetStringResponse("status/" + StatusID);
        }

        public void GetCollections()
        {
            try
            {
                CollectionResource[] resources = JsonSerializer.Deserialize<CollectionsResource>(GetStringResponse("collections/")).Collections;
                foreach (CollectionResource resource in resources)
                {
                    Collections.Add(new Collection(FormatURL(BaseServer, "collections/" + resource.Id + "/"), resource));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
