using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW2_ASP.Models;

namespace HW2_ASP.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Admins()
        {
            
            

            return View(new NotActiveUsersModel());
        }

        public ActionResult _PartialAdmins(object item)
        {

            return View(item);
        }

        [HttpPost]
        public ActionResult Admins(NotActiveUsersModel model,bool[] checkedList)
        {
            int a;
            a = 10;
            
            return View();
        }
    }
}