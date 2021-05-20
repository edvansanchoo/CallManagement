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
       

        // GET: CreateIncident
        public ActionResult CreateIncident()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            ModelIncidents incidents = new ModelIncidents();


            incidents.NumberIncident = incidents.generationNumberIncident();
            incidents.Caller = Request["Caller"];
            incidents.Status = "Open";
            incidents.WorkNotes = Request["WorkNotes"];
            incidents.ResolutionInformation = "";

            incidents.Save();
            
            return RedirectToAction("CreateIncident");

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
        
        public ActionResult AllIncident()
        {
            ViewBag.ModelIncidents = new ModelIncidents().ListIncident();
            return View();
        }

        [HttpPost]
        public ActionResult SearchIncident()
        {
            var NumberIncident = Request["searchIncident"];
            ViewBag.ModelIncidents = new ModelIncidents().SearchIncident(NumberIncident);

            return RedirectToAction("AllIncident");
        }
    }
}