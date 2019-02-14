using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW2_ASP.Models;

namespace HW2_ASP.Controllers
{
    public class RegistrateController : Controller
    {
        // GET: Registrate
        public ActionResult Registrate()
        {
            ViewBag.Danger_Login = "False";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrate(User register, string action)
        {
            if (action=="Registrate")
            {
                using (var db = new MusicalPortal())
                {
                    var tmp = db.User.Any(i => i.login == register.login);
                    if (tmp)
                    {
                        ViewBag.Danger_Login = "True";
                        ModelState.AddModelError("login", "This login is exist!");
                        return View(register);
                    }

                    GetHeshMd5 hash = new GetHeshMd5();
                    register.password = hash.GetHesh(register.password);
                    db.User.Add(register);
                    db.SaveChanges();
                    return View(register);
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View(register);
        }

    }

}