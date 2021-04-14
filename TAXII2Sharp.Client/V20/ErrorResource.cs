using System;
using System.Collections.Generic;
using System.Text;

namespace TAXII2Sharp.Client.V20
{
    public class ErrorResource
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Error_Id { get; set; }
        public String Error_Code { get; set; }
        public String Http_Status { get; set; }
        public String External_Details { get; set; }
        public Dictionary<String, String> Details { get; set; }
    }
}
