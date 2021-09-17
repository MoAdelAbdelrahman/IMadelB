
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using rentee.Models;

namespace rentee.Models
{
    public class CustomAgeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.birthDate == null)
            {
                return new ValidationResult("Birthdate is required for a membership.");
            }

            var age = DateTime.Now.Year - customer.birthDate.Value.Year;

            return (age >= 18 ?
                ValidationResult.Success :
                new ValidationResult("You have to be 18+ for a membership."));
        }
    }
}