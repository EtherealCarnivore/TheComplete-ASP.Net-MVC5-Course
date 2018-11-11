using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;

namespace VidlyProject.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unkown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo) return ValidationResult.Success;

            if (customer.Birthdate == null) return new ValidationResult
                ("The customer should be at least 18 years old to go on a membership plan.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("The customer should be at least 18 years old to go on a membership plan.");


        }

    }
}