﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ErrorPageController : Controller
    {
       
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            return View();
        }
        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}