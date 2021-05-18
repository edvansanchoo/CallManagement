using CallManagement.Models.DB;
using CallManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallManagement.Controllers
{
    public class IncidentController : Controller
    {
        private object incidents;

        // GET: CreateIncident
        public ActionResult CreateIncident()
        {
            ModelIncidents incidents = new ModelIncidents();
            DaoIncidents daoIncidents = new DaoIncidents();

            /*
            incidents.NumberIncident = daoIncidents.generationNumberIncident(); 
            incidents.Caller = Request["Caller"];
            incidents.Status = Request["Status"];
            incidents.WorkNotes = Request["WorkNotes"];
            incidents.ResolutionInformation = Request["ResolutionInformation"];
            */

            incidents.NumberIncident = daoIncidents.generationNumberIncident(); ;
            incidents.Caller = "João Marcos";
            incidents.Status = "Open";
            incidents.WorkNotes = "The print with low ink";
            incidents.ResolutionInformation = "In proguess";

            daoIncidents.Save(incidents);

            return RedirectToAction("./StartView");
        }

        public void AlterIncident(String numberIncident)
        {
            var incidents = new ModelIncidents();
            var daoIncidents = new DaoIncidents();

            foreach (DataRow row in daoIncidents.SearchByNumberIncident(numberIncident).Rows)
            {
                incidents.NumberIncident = Convert.ToString(row["NumberIncident"]);
                incidents.Caller = Convert.ToString(row["Caller"]);
                incidents.Status = Convert.ToString(row["Status"]);
                incidents.WorkNotes = Convert.ToString(row["WorkNotes"]);
                incidents.ResolutionInformation = Convert.ToString(row["ResolutionInformation"]);
            }

            if(incidents != null)
            {
                
                incidents.Caller = Request["Caller"];
                incidents.Status = Request["Status"];
                incidents.WorkNotes = Request["WorkNotes"];
                incidents.ResolutionInformation = Request["ResolutionInformation"];

                daoIncidents.AlterIncident(incidents);
            
            }


        }
    }
}