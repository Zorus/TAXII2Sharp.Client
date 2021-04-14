using System;
using System.IO;
using System.Net;
using System.Text;

namespace TAXII2Sharp_Client
{
    public class TAXIIClient
    {
        public TAXIIClient(String TAXIIServerBase, String MediaType)
        {
            BasePath = TAXIIServerBase;
            this.MediaType = MediaType;
        }

        public TAXIIClient(String TAXIIServerBase, String MediaType, String Auth)
        {
            BasePath = TAXIIServerBase;
            AuthToken = Auth;
            this.MediaType = MediaType;
        }

        public TAXIIClient(String TAXIIServerBase, String MediaType, String User, String Pass)
        {
            BasePath = TAXIIServerBase;
            this.MediaType = MediaType;
            AuthToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(User + ":" + Pass));
        }

        public String BasePath { get; set; }
        public String AuthToken { get; set; } = String.Empty;

        public String UserAgent { get; set; } = Common.DEFAULT_USER_AGENT;
        public String MediaType { get; set; } = Common.MEDIA_TYPE_TAXII_V20;

        public String GetStringResponse(String URI)
        {
            return GetStringResponse(URI, this.MediaType);
        }

        public String GetStringResponse(String URI, String MediaType)
        {
            String EndpointValue = FormatURL(BasePath, URI);

            Console.WriteLine(EndpointValue);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndpointValue);



            if (AuthToken != String.Empty)
            {
                request.Headers.Add("Authorization", "Basic " + this.AuthToken);
            }

            request.UserAgent = UserAgent;
            request.Accept = MediaType;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Authentication required. See TAXII Implementation 1.4.8");
            }

            String ResponseValue = "";

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                ResponseValue = reader.ReadToEnd();
            }

            return ResponseValue;
        }

        public String FormatURL(String ServerBase, String URI)
        {
            String EndpointValue = ServerBase;
            if (EndpointValue[EndpointValue.Length - 1] != '/')
            {
                EndpointValue += "/";
            }

            if (URI.Length > 0)
            {
                EndpointValue += URI;
                if (EndpointValue[EndpointValue.Length - 1] != '/')
                {
                    EndpointValue += "/";
                }
            }


            return EndpointValue;
        }
    }
    public class Common
    {
        public static string Version = "2.3.0";
        public static string DEFAULT_USER_AGENT = "taxii2-client/" + Version;
        public static string MEDIA_TYPE_STIX_V20 = "application/vnd.oasis.stix+json; version=2.0";
        public static string MEDIA_TYPE_TAXII_V20 = "application/vnd.oasis.taxii+json; version=2.0";
        public static string MEDIA_TYPE_TAXII_V21 = "application/taxii+json;version=2.1";

    }
}
