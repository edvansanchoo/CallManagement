﻿using System;
using System.Collections.Generic;
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
    }
}