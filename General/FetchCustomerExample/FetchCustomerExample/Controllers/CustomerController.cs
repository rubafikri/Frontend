using FetchCustomerExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetchCustomerExample.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customers = new List<Customer>();



        [HttpGet]
        public IActionResult Index()
        {
            return View(customers.ToList());
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Json(customers.ToList());
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            customers.Add(customer);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AddJsonCustomer([FromBody] Customer customer)
        {
            customers.Add(customer);
            return Json(customer);
        }
    }
}
