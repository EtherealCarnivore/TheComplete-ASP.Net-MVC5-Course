﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    //we need this in order to create the form for the new customer and encapsulate all changes to the customer class
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //in the view we don't need any of the functionality
                                                                         //of the list class, we need to initirate over membershiptypes 
                                                                         //this is why I am using this ienumerable class
        public Customer Customer { get; set; }

        public string Title // I use this logic to handle the title of the Movie Form in the view
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return " ";
                }
                else
                {
                    return "New Customer";
                }
            }
        }
    }
}