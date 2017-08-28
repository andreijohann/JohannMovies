using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JohannMovies.Models;
using JohannMovies.ViewModel;
using System;

namespace JohannMovies.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        // GET: Customers
        // GET: Customers/Index/{PageIndex}/{SortBy}
        public ActionResult Index(int? PageIndex, string SortBy)
        {

            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            var customers = _context.Customers.Include(c => c.MembershipType).ToList<Customer>();

            var modelView = new IndexCustomersViewModel
            {
                Customers = customers
            };

            return View(modelView);
        }


        // GET: Customers/Details/1
        public ActionResult Details(int Id)
        {

            var objCustomer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (objCustomer == null) {
                return HttpNotFound();
            }

            var modelView = new DetailsCustomerViewModel
            {
                Customer = objCustomer
            };
            return View(modelView);
        }


    }


}
