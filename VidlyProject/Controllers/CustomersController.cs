using System;
using System.Data.Entity; //we need to add this in order to access the membershiptype property outside of the class
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModels;

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

        // Dropdownlist - we get the list of membership types from the database and pass it into a view "New"
        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList(); // in order to access this we need to add a
                                                                     // new DBSet in the IdendityModels

            var viewModel = new CustomerFormViewModel //create a model to encapsulate
                                                     //all changes done to the customer class later we do this by creating
                                                     //a new viewmodel called NewCustomerViewModel 

            {
                Customer = new Customer(), //we need this to initialize all the values in the customer form (remove ID warning)
                MembershipTypes = membershipTypes 
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost] // this attribute makes sure that the action can only be called by POST and not GET
        public ActionResult Save(Customer customer) //bind model to request data
        {
            if (!ModelState.IsValid) //change the flow of the program, if not valid return same view
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer, //this is required to populate the values in the form
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
            }
            
            _context.SaveChanges(); //saves the changes to the DB via SQL statements

            return RedirectToAction("Index", "Customers"); //redirect user back
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
            // we need this LINQ and lambda expressions in order to render the customer in a view

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) 
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }


       
    }
}