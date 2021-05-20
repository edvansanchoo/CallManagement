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
            incidents.WorkNotes = Request[""];
            incidents.ResolutionInformation = "";
            incidents.Description = Request["Description"];

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
                incidents.Description = Convert.ToString(row["Description"]);
            }


            if (incidents != null)
            {
                incidents.NumberIncident = Request["NumberIncident"];
                incidents.Caller = Request["Caller"];
                incidents.Status = Request["Status"];
                incidents.WorkNotes = Request["WorkNotes"];
                incidents.ResolutionInformation = Request["ResolutionInformation"];
                incidents.Description = Request["Description"];

                daoIncidents.AlterIncident(incidents);
            
            }
        }
        
        public ActionResult AllIncident()
        {

            var NumberIncident = Request["searchIncident"];

            if(NumberIncident != null && NumberIncident != "")
            {
                ViewBag.ModelIncidents = new ModelIncidents().SearchIncident(NumberIncident);
            }
            else
            {
                ViewBag.ModelIncidents = new ModelIncidents().ListIncident();
            }
            return View();
        }

        public ActionResult EditIncident()
        {
            return View();
        }

        public ActionResult CloseIncident()
        {
            return View();
        }
    }
}