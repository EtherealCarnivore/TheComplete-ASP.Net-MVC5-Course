using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}