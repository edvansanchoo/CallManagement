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
            request.ShortDescription = Request["SortDescription"];

            request.Save();

            return RedirectToAction("CreateRequest");
        }

        public ActionResult AllRequest()
        {
            
            return View();
        }

        public ActionResult EditRequest(String NumberRequest)
        {
            ViewBag.ModelRequest = new ModelRequest().SearchRequestByNumber(NumberRequest);
            return View();
        }

        public ActionResult CloseRequest()
        {
            return View();
        }

    }
}