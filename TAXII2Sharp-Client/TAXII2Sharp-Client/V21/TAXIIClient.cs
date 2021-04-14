using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TAXII2Sharp_Client.V21
{

    public class Collection : TAXIIClient
    {
        public Collection(String URI, CollectionResource Resource) : base(URI, Common.MEDIA_TYPE_TAXII_V21)
        { 
            this.Resource = Resource;
        }

        public String GetCollection()
        {
            String response = GetStringResponse("");

            return response;
        }

        public ManifestRecordResource[] GetManifests()
        {
            ManifestRecordResource[] manifests = JsonSerializer.Deserialize<ManifestRecordResource[]>(GetStringResponse("manifest/"));
            return manifests;
        }


        public String GetObjects()
        {
            return GetStringResponse("objects/");
        }

        public CollectionResource Resource { get; set; }

    }

    public class APIRoot : TAXIIClient
    {
        public APIRoot(String URI) : base(URI, Common.MEDIA_TYPE_TAXII_V21)
        {
            BaseServer = URI;
            Resource = JsonSerializer.Deserialize<APIRootResource>(GetBase());
            GetCollections();

        }

        public String BaseServer { get; set; }

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
                    Collections.Add(new Collection( FormatURL(BaseServer, "collections/" + resource.Id + "/"), resource));
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public APIRootResource Resource { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();
    }
}
