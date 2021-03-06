﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // this sets the string to not nullable in the db and it's maximum length 
        [Required(ErrorMessage = "Please enter the customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        //adding the [Display] annotation allows us to render the properties with a display name
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select a membership type.")]
        public byte MembershipTypeId { get; set; }

        
        [Min18YearsIfAMember] //validate if customer has 18
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }


    }
}