using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rentee.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult New()
        {
            if (Request.IsAuthenticated)
             return View();

            return View("Login");
        }
    }
}