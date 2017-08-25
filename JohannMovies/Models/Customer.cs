using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Customer> GetAllCustomers()
        {
            var Customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Mick Fanning"},
                new Customer { Id = 2, Name = "Kelly Slater"}
            };
            return Customers;
        }


    }
}