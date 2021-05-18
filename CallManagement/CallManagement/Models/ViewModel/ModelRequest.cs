using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelRequest
    {
        public String NumberRequest { get; set; }
        public String RequestFor { get; set; }
        public String Status { get; set; }
        public String Item { get; set; }
        public String WorkNotes { get; set; }
        public String ShortDescription { get; set; }
    }
}