using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TAXII2Sharp.Client.STIX;


namespace TAXII2Sharp.Client.V21
{

    public class Collection : TAXIIClient
    {
        public CollectionResource Resource { get; set; }
        
        public Collection(String URI, CollectionResource Resource) : base(URI, MIMETypes.TAXII_V21)
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

        public Bundle GetObject(String Id)
        {
            StringBuilder sb = new StringBuilder();
            if (Resource.Media_Types != null && Resource.Media_Types.Length > 0)
            {
                sb.Append(Resource.Media_Types[0]);
            }
            return JsonSerializer.Deserialize<Bundle>(GetStringResponse("objects/" + Id + "/", sb.ToString()));
        }

    }
}
