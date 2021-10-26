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
       

        //GET: CreateIncident
        public ActionResult CreateIncident()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            ModelIncident incidents = new ModelIncident();


            incidents.NumberIncident = incidents.generationNumberIncident();
            incidents.Caller = Request["Caller"];
            incidents.Status = "Open";
            incidents.WorkNotes = Request[""];
            incidents.ResolutionInformation = "";
            incidents.Description = Request["Description"];
            incidents.dateLimiteRequest();

            incidents.Save();
            
            return RedirectToAction("CreateIncident");

        }

        
        public ActionResult AllIncident()
        {

            var NumberIncident = Request["searchIncident"];

            if(NumberIncident != null && NumberIncident != "")
            {
                ViewBag.ModelIncidents = new ModelIncident().SearchIncident(NumberIncident);
            }
            else
            {
                ViewBag.ModelIncidents = new ModelIncident().ListIncident();
            }
            return View();
        }

        public ActionResult EditIncident(String NumberIncident)
        {
            
            ViewBag.ModelIncidents = new ModelIncident().SearchIncidentByNumber(NumberIncident);
           
            return View();
        }


        public ActionResult AlterIncident()
        {
            var incidents = new ModelIncident();

            incidents.NumberIncident = Request["NumberIncident"];
            incidents.Caller = Request["Caller"];
            incidents.Status = "Assigned";
            incidents.WorkNotes = Request["WorkNotes"];
            incidents.ResolutionInformation = Request["ResolutionInformation"];
            incidents.Description = Request["Description"];
            //incidents.IdTecnico = Request["idTecnico"];
            incidents.Tecnico = Request["idNameTec"];

            incidents.AlterIncidentByNumber(incidents);

            return RedirectToAction("AllIncident");

        }

        public ActionResult ClosingIncident()
        {
            var incidents = new ModelIncident();

            incidents.NumberIncident = Request["NumberIncident"];
            incidents.Caller = Request["Caller"];
            incidents.Status = "Closed";
            incidents.WorkNotes = Request["WorkNotes"];
            incidents.ResolutionInformation = Request["ResolutionInformation"];
            incidents.Description = Request["Description"];
            incidents.Tecnico = Request["idNameTec"];

            incidents.AlterIncidentByNumber(incidents);

            return RedirectToAction("AllIncident");

        }

        public ActionResult CloseIncident(String NumberIncident)
        {
            ViewBag.ModelIncidents = new ModelIncident().SearchIncidentByNumber(NumberIncident);

            return View();

        }
    }
}