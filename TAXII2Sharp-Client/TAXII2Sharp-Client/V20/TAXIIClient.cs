using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TAXII2Sharp_Client.STIX;

namespace TAXII2Sharp_Client.V20
{
    public class Collection : TAXIIClient
    {
        public Collection(String URI, CollectionResource Resource) : base(URI, Common.MEDIA_TYPE_TAXII_V20)
        {
            this.Resource = Resource;
        }

        public String GetCollection()
        {
            String response = GetStringResponse("");

            return response;
        }

        public ManifestResource[] GetManifests()
        {
            ManifestResource[] manifests = JsonSerializer.Deserialize<ManifestResource[]>(GetStringResponse("manifest/"));
            return manifests;
        }


        public Bundle GetObjects()
        {
            // TODO: This is an array of strings, therefore we should accept more than just that initial value
            StringBuilder sb = new StringBuilder();
            if (Resource.Media_Types != null && Resource.Media_Types.Length >0)
            {
                sb.Append(Resource.Media_Types[0]);
            }

            return JsonSerializer.Deserialize<Bundle>(GetStringResponse("objects/", sb.ToString()));
        }

        public CollectionResource Resource { get; set; }

    }

    public class APIRoot : TAXIIClient
    {
        public APIRoot(String URI) : base(URI, Common.MEDIA_TYPE_TAXII_V20)
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
                    Collections.Add(new Collection(FormatURL(BaseServer, "collections/" + resource.Id + "/"), resource));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public APIRootResource Resource { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();
    }
}
