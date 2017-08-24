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
            //return Json(Movie, JsonRequestBehavior.AllowGet);
            //return Redirect(@"~\Util\WebFormTest.aspx");
            //return PartialView(@"~\Views\Movies\Random.cshtml", Movie);
            //return File(new System.IO.StreamReader(Server.MapPath("~/Util/Download.docx")).BaseStream, "application/ms-word", "DwnFile.docx");
            return RedirectToAction("Index", "Home", new { pageIndex = 1, SortBy = "Name" });
        }

        //GET: Movies/Edit/1 
        public ActionResult Edit(int id) {

            return Content("id=" + id);

        }

        public ActionResult Index(int? PageIndex, string SortBy) {

            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            return Content("PageIndex=" + PageIndex + "&SortBy=" + SortBy);
        }
    }
}