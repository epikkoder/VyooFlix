using System.Collections.Generic;
using System.Web.Mvc;
using VyooFlix.Models;

namespace VyooFlix.Controllers
{
    public class CustomersController : Controller
    {
	    private List<Customer> customers = new List<Customer>
	    {
			new Customer {Id = 1, Name = "John Smith"},
			new Customer {Id = 2, Name = "Amy Lee"}
	    };

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

	    public ActionResult Details(int id)
	    {
		    Customer customer = null;
		    foreach (Customer c in customers)
		    {
			    if (c.Id == id)
				    customer = c;
		    }

		    if (customer == null)
			    return HttpNotFound();

		    return View(customer);
	    }
    }
}