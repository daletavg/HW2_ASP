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

        [HttpPost]
        public ActionResult Admins(NotActiveUsersModel model)
        {
            using (var db = new MusicPortal())
            {
                var notActiveUser = db.Users.Where(d => d.is_activate == false);
                foreach (var i in model.Users.Where(k=>k.is_activate==false))
                {
                    notActiveUser.First(j => j.login == i.login).is_activate = true;
                }

                db.SaveChanges();

            }
            return View();
        }
    }
}