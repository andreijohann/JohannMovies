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
            return View(Movie);
        }
    }
}