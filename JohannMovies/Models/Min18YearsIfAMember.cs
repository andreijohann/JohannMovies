using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace JohannMovies.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {

        private int GetAge(DateTime dateOfBirth, DateTime dateAsAt)
        {
            return dateAsAt.Year - dateOfBirth.Year - (dateOfBirth.DayOfYear < dateAsAt.DayOfYear ? 0 : 1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            /*
             If select a MembershipType different than PayAsYouGo, a customer must have at least 18 years old.
             */
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                   return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            return  (GetAge(customer.Birthdate.Value, DateTime.Now) >= 18) 
                ? ValidationResult.Success
                : new ValidationResult("Custumer should be at least 18 years old to go on a Membership.");
            

        }
    }
}