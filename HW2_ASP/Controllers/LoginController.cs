using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HW2_ASP.Models;

namespace HW2_ASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       
        public ActionResult Login()
        {
            ViewBag.Danger_Login = "False";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel logon, string action)
        {
            if (action == "Login")
            {
                return LoginOnSite(logon);
            }
            else
            {
                return RedirectToAction("Registrate", "Registrate");
            }
        }

        private ActionResult LoginOnSite(LoginModel logon)
        {
            if (ModelState.IsValid)
            {
                using (var db = new MusicPortal())
                {


                    if (db.Users.AsNoTracking().ToList().Count == 0)
                    {
                        ViewBag.Danger_Login = "True";
                        ModelState.AddModelError("Login", "Wrong login!");
                        return View(logon);
                    }

                    var users = db.Users.Where(a => a.login == logon.Login);
                    if (users.ToList().Count == 0)
                    {
                        ViewBag.Danger_Login = "True";
                        ModelState.AddModelError("Login", "Wrong login!");
                        return View(logon);
                    }

                    var user = users.First();
                    if (GetHeshMd5.CheckHeshMD5(user.password, new GetHeshMd5().GetHesh(logon.Password)))
                    {
                        ViewBag.Danger_Login = "True";
                        ModelState.AddModelError("Login", "Wrong password?");
                        return View(logon);
                    }




                    Session["Name"] = user.name;
                    Session["Surname"] = user.surname;
                    switch (user.Status.id)
                    {
                        case 1:
                            Session["Admin"] = "Admin";
                            break;
                        default:
                            Session["Admin"] = "User";
                            break;
                    }
                    return RedirectToAction("General", "General");
                }

                return View(logon);
            }
            throw new Exception("Failed load database!");
        }


    }
}