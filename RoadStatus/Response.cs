using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatus
{
    class Response
    {       
        public string id { get; set; }
        public string displayName { get; set; }
        public string statusSeverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public string url { get; set; }        
    }
}
