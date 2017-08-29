using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JohannMovies.Models;
using JohannMovies.Dtos;
using AutoMapper;

namespace JohannMovies.Controllers.Api
{
    public class CustomersController : ApiController
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

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers() {

            return _context.Customers.ToArray().Select(Mapper.Map<Customer, CustomerDto>);

        }

        //GET /api/customers/1
        public CustomerDto GetCustomer(int Id) {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto) {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto) {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id) {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}
