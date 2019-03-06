using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW2_ASP.Models;

namespace HW2_ASP.Controllers
{
    public class AddMusicController : Controller
    {
        // GET: AddMusic
        public ActionResult AddMusic()
        {
            using (var db = new MusicPortal())
            {
                List<Genre> genr = new List<Genre>();
                foreach (var dbGenre in db.Genres.ToList())
                {
                    genr.Add(dbGenre);
                }

                ViewBag.Geners = genr;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddMusic(IEnumerable<HttpPostedFileBase> fileUpload)
        {

            int count = 0;
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                string filename = Path.GetFileName(file.FileName);
                string tempfolder = Server.MapPath("~/Musics");
                if (filename != null)
                {
                    file.SaveAs(Path.Combine(tempfolder, filename));
                    count++;
                }
            }

            ViewBag.IsUpload = "Файл успешно загружен!";
            return View();
        }
    }
}
