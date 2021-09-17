using CallManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallManagement.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            ModelRequest request = new ModelRequest();

            request.NumberRequest = request.generationNumberRequest();
            request.RequestFor = Request["RequestBy"];
            request.Status = "Open";
            request.Item = Request["Item"];
            request.ShortDescription = Request["ShortDescription"];
            //request.IdTecnico = Request["idTecnicoRequest"];
            request.Tecnico = Request["idNameTecRequest"];
            request.dateLimiteRequest();

            request.Save();

            return RedirectToAction("CreateRequest");
        }

        public ActionResult AllRequest()
        {

            var NumberRequest = Request["searchRequest"];

            if (NumberRequest != null && NumberRequest != "")
            {
                ViewBag.ModelRequest = new ModelRequest().SearchRequestByNumber(NumberRequest);
            }
            else
            {
                ViewBag.ModelRequest = new ModelRequest().ListRequest();
            }
            return View();
        }

        public ActionResult EditRequest(String NumberRequest)
        {
            ModelRequest request = new ModelRequest();
            List<ModelRequest> lista = new ModelRequest().SearchRequestByNumber(NumberRequest);

            foreach (ModelRequest modelrequest in lista)
            {

                request.NumberRequest = modelrequest.NumberRequest;
                request.RequestFor = modelrequest.RequestFor;
                request.Status = modelrequest.Status;
                request.Item = modelrequest.Item;
                request.WorkNotes = modelrequest.WorkNotes;
                request.ShortDescription = modelrequest.ShortDescription;
                //request.IdTecnico = modelrequest.IdTecnico;
                request.Tecnico = modelrequest.Tecnico;
            }

            ViewBag.ModelRequest = request;
            return View();
        }

        public ActionResult CloseRequest(String NumberRequest)
        {
            ModelRequest request = new ModelRequest();
            List<ModelRequest> lista = new ModelRequest().SearchRequestByNumber(NumberRequest);

            foreach (ModelRequest modelrequest in lista)
            {

                request.NumberRequest = modelrequest.NumberRequest;
                request.RequestFor = modelrequest.RequestFor;
                request.Status = modelrequest.Status;
                request.Item = modelrequest.Item;
                request.WorkNotes = modelrequest.WorkNotes;
                request.ShortDescription = modelrequest.ShortDescription;
                //request.IdTecnico = modelrequest.IdTecnico;
                request.Tecnico = modelrequest.Tecnico;

            }

            ViewBag.ModelRequest = request;
            return View();
        }

        public ActionResult AlterRequest()
        {
            ModelRequest request = new ModelRequest();

            request.NumberRequest = Request["CallerRequest"];
            request.RequestFor = Request["Caller"];
            request.Status = "Assigned";
            request.Item = Request["LabelName"];
            request.WorkNotes = Request["WorkNotes"];
            request.ShortDescription = Request["ShortDescription"];
            //request.IdTecnico = Request["idTecnicoRequest"];
            request.Tecnico = Request["idNameTecRequest"];

            request.AlterRequest();

            return RedirectToAction("AllRequest");
            return View();
        }

        public ActionResult ClosingRequest()
        {
            ModelRequest request = new ModelRequest();

            request.NumberRequest = Request["CallerRequest"];
            request.RequestFor = Request["Caller"];
            request.Status = "Closed";
            request.Item = Request["LabelName"];
            request.WorkNotes = Request["WorkNotes"];
            request.ShortDescription = Request["ShortDescription"];
            //request.IdTecnico = Request["idTecnicoRequest"];
            request.Tecnico = Request["idNameTecRequest"];

            request.AlterRequest();

            return RedirectToAction("AllRequest");
            return View();

        }
    }
}