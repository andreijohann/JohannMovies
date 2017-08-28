using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JohannMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //NavigationProperty
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }



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