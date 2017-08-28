using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using JohannMovies.Models;
using JohannMovies.ViewModel;

namespace JohannMovies.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Movies
        // GET: Movies/Index/{PageIndex}/{SortBy}
        public ActionResult Index(int? PageIndex, string SortBy)
        {

            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            var movies = _context.Movies.Include(mbox => mbox.Genre).ToList<Movie>();

            var modelView = new IndexMoviesViewModel
            {
                Movies = movies
            };

            return View(modelView);
        }

        // GET: Movies/Details/1
        public ActionResult Details(int Id)
        {

           var objMovie = _context.Movies.Include(mbox => mbox.Genre).SingleOrDefault(m => m.Id == Id);

            if (objMovie == null)
            {
                return HttpNotFound();
            }

            var modelView = new DetailsMovieViewModel
            {
                Movie = objMovie
            };

            return View(modelView);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie(){
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);

            /* Playing with Action Results */
            //return Content("Random Method!");
            //return HttpNotFound();
            //return new EmptyResult();            
            //return Json(Movie, JsonRequestBehavior.AllowGet);
            //return Redirect(@"~\Util\WebFormTest.aspx");
            //return PartialView(@"~\Views\Movies\Random.cshtml", Movie);
            //return File(new System.IO.StreamReader(Server.MapPath("~/Util/Download.docx")).BaseStream, "application/ms-word", "DwnFile.docx");
            //return RedirectToAction("Index", "Home", new { pageIndex = 1, SortBy = "Name" });
        }

        //GET: Movies/Edit/1 
        public ActionResult Edit(int id) {

            return Content("id=" + id);

        }



        /*
        Good docs about attribute routing: https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/ 
        */

        //[Route("movies/released/{year}/{month}")]
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{1,2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            return Content(String.Format("{0}/{1}", year, month));
        }
    }

    
}