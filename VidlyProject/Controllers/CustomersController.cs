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


        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
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
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }


            return View(customer);

        }

       
    }
}