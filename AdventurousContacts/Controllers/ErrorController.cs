﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventurousContacts.Controllers
{
    public class ErrorController : Controller
    {
       
        // GET: /Error/

        public ActionResult Error()
        {
            return View("Error");
        }

        // GET: /Error/
        
        public ActionResult Error404()
        {
            return View("Error404");
        }

    }
}
