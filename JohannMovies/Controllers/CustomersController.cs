using System.Collections.Generic;
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

        // GET: Customers
        // GET: Customers/Index/{PageIndex}/{SortBy}
        public ActionResult Index(int? PageIndex, string SortBy)
        {

            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (String.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            var customers = Customer.GetAllCustomers();

            var modelView = new IndexCustomersViewModel
            {
                Customers = customers
            };

            return View(modelView);
        }


        // GET: Customers/Details/1
        public ActionResult Details(int Id)
        {

            var objCustomer = Customer.GetAllCustomers().Where(m => m.Id == Id).SingleOrDefault();
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
