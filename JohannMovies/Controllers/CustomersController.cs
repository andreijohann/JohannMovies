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

            return View();
        }


        // GET: Customers/Details/1
        public ActionResult Details(int Id)
        {

            var objCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (objCustomer == null) {
                return HttpNotFound();
            }

            var modelView = new DetailsCustomerViewModel
            {
                Customer = objCustomer
            };
            return View(modelView);
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList<MembershipType>();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid) {

                var vm = new CustomerFormViewModel() {

                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", vm);

            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else {

                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TODO: Replace this block with AutoMapper api
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel() {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }


}
