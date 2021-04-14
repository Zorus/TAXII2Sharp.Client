using System;
using System.Collections.Generic;
using System.Text;

namespace TAXII2Sharp.Client.STIX
{
    public class GranularMarking
    {
        public String Marking_Ref { get; set; }
        public String[] Selectors { get; set; }
    }
}
