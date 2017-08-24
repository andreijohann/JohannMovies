using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannMovies.Models;

namespace JohannMovies.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var Movie = new Movie(){
                Name = "Shrek!"
            };

            //return View(Movie);

            /* Playing with Action Results */
            //return Content("Random Method!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home");
            //return Json(Movie, JsonRequestBehavior.AllowGet);
            //return Redirect(@"~\Util\WebFormTest.aspx");
            //return PartialView(@"~\Views\Movies\Random.cshtml", Movie);
            return File(new System.IO.StreamReader(Server.MapPath("~/Util/Download.docx")).BaseStream, "application/ms-word", "DwnFile.docx");


        }
    }
}