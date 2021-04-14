using System;
using System.IO;
using System.Net;
using System.Text;

namespace TAXII2Sharp.Client
{
    public class TAXIIClient
    {
        private const string TAXIIVersion = "2.3.0";
        private const string DEFAULT_USER_AGENT = "taxii2-client/" + TAXIIVersion;
        public String BasePath { get; set; }
        public String AuthToken { get; set; } = String.Empty;

        public String UserAgent { get; set; } = DEFAULT_USER_AGENT;
        public String MIMEType { get; set; } = GetMIMEValue(MIMETypes.TAXII_V20);

        public enum MIMETypes
        {
           STIX_V20,
           TAXII_V20,
           TAXII_V21
        }

        public TAXIIClient(String TAXIIServerBase, MIMETypes MIMEType)
        {
            BasePath = TAXIIServerBase;
            this.MIMEType = GetMIMEValue(MIMEType);
        }

        public TAXIIClient(String TAXIIServerBase, MIMETypes MIMEType, String Auth)
        {
            BasePath = TAXIIServerBase;
            AuthToken = Auth;
            this.MIMEType = GetMIMEValue(MIMEType);
        }

        public TAXIIClient(String TAXIIServerBase, MIMETypes MIMEType, String User, String Pass)
        {
            BasePath = TAXIIServerBase;
            this.MIMEType = GetMIMEValue(MIMEType);
            AuthToken = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(User + ":" + Pass));
        }
        private static String GetMIMEValue(MIMETypes MIMEType)
        {
            switch (MIMEType)
            {
                case MIMETypes.STIX_V20: return "application/vnd.oasis.stix+json; version=2.0";
                case MIMETypes.TAXII_V20: return "application/vnd.oasis.taxii+json; version=2.0";
                case MIMETypes.TAXII_V21: return "application/taxii+json;version=2.1";
                default: return String.Empty;
            }
        }

        public String GetStringResponse(String URI)
        {
            return GetStringResponse(URI, this.MIMEType);
        }

        public String GetStringResponse(String URI, String MIMEType)
        {
            String EndpointValue = FormatURL(BasePath, URI);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndpointValue);



            if (AuthToken != String.Empty)
            {
                request.Headers.Add("Authorization", "Basic " + this.AuthToken);
            }

            request.UserAgent = UserAgent;
            request.Accept = MIMEType;

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
}
