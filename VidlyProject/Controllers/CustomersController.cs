using System;
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
        public ActionResult Index()
        {
            var customers = new List<Customer>{
                new Customer {Id = 1, Name = "Nikola Kanev"},
                new Customer {Id = 2, Name = "Konstantin Genov"}

            };
           
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customers");
            }
            if (id == 0)
            {
                return RedirectToAction("Index", "Customers");
            }
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
           
            if (customer == null)
            {
                return HttpNotFound();
            }

            
            return View(customer);

        }

        private List<Customer> GetCustomers() // we need this in a method so we can use LINQ and lambda expressions
        {
            return new List<Customer>  {
                new Customer {Id = 1, Name = "Nikola Kanev"},
                new Customer {Id = 2, Name = "Konstantin Genov"}

            };
        }
    }
}