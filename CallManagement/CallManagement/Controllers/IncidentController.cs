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
            ModelIncidents incidents = new ModelIncidents();


            incidents.NumberIncident = incidents.generationNumberIncident();
            incidents.Caller = Request["Caller"];
            incidents.Status = "Open";
            incidents.WorkNotes = Request[""];
            incidents.ResolutionInformation = "";
            incidents.Description = Request["Description"];
            incidents.dateLimiteRequest();

            incidents.Save();
            TempData["Employee"] = Request["Caller"];
            return RedirectToAction("AllIncident");

        }

        
        public ActionResult AllIncident()
        {

            var NumberIncident = Request["searchIncident"];
            String serialNumber = TempData["Employee"].ToString();
            ModelEmployee employee = new ModelEmployee().SearchEmployeeByNumber(serialNumber);

            if(employee.IsTecnic == 1)
            {
                if (NumberIncident != null && NumberIncident != "")
                {
                    ViewBag.ModelIncidents = new ModelIncidents().SearchIncident(NumberIncident);
                }
                else
                {
                    ViewBag.ModelIncidents = new ModelIncidents().ListIncident();
                }
            }
            else
            {
                if (NumberIncident != null && NumberIncident != "")
                {
                    ViewBag.ModelIncidents = new ModelIncidents().SearchIncident(NumberIncident, employee.SeriaNumber);
                }
                else
                {
                    ViewBag.ModelIncidents = new ModelIncidents().ListIncident(employee.SeriaNumber);
                }
            }
            TempData["Employee"] = serialNumber;
            return View();

        }

        public ActionResult EditIncident(String NumberIncident)
        {
            
            ViewBag.ModelIncidents = new ModelIncidents().SearchIncidentByNumber(NumberIncident);
           
            return View();
        }


        public ActionResult AlterIncident()
        {
            var incidents = new ModelIncidents();

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
            var incidents = new ModelIncidents();

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
            ViewBag.ModelIncidents = new ModelIncidents().SearchIncidentByNumber(NumberIncident);

            return View();

        }
    }
}