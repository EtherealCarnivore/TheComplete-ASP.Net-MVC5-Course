using System;
using System.Data.Entity; //we need to add this in order to access the membershiptype property outside of the class
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;

namespace VidlyProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers


        private ApplicationDbContext _context; //this way we access the database

        public CustomersController() 
        {
            _context = new ApplicationDbContext(); //intialize the context variable
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //in order for the view to work we need to cast it ToList

            return View(customers);                                                   //we use the Include method + the lamba expression to show the info
        }

        public ActionResult Details(int? id)
        {
            if (id == null) // if there's no id in details there will be a redirection
            {
                return RedirectToAction("Index", "Customers");
            }
            if (id == 0) //same as above but with 0 value of id
            {
                return RedirectToAction("Index", "Customers");
            }
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }


            return View(customer);

        }

       
    }
}