using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelIncidents
    {
        public String NumberIncident { get; set; }
        public String Caller { get; set; }
        public String Status { get; set; }
        public String WorkNotes { get; set; }
        public String ResolutionInformation { get; set; }

    }
}