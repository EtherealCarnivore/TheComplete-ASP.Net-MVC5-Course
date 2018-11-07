using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    //we need this in order to create the form for the new customer and encapsulate all changes to the customer class
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //in the view we don't need any of the functionality
                                                                         //of the list class, we need to initirate over membershiptypes 
                                                                         //this is why I am using this ienumerable class
        public Customer Customer { get; set; }
    }
}