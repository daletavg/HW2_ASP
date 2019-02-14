using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW2_ASP.Controllers
{
    public class GeneralController : Controller
    {
        // GET: General
        public ActionResult General()
        {
            Session["Admin"] = "User";
            return View();
        }
    }
}