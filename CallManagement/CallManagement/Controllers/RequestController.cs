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

        public ActionResult AllRequest()
        {
            return View();
        }

        public ActionResult EditRequest()
        {
            return View();
        }

        public ActionResult CloseRequest()
        {
            return View();
        }
    }
}