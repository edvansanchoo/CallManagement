using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallManagement.Controllers
{
    public class StartViewController : Controller
    {
        // GET: StartView
        public ActionResult Index()
        {
            return View();
        }
    }
}