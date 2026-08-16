using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class CustomerController(StoreContext _context) : Controller
    {
        public IActionResult CustomerListOrderByCustomerName(int page = 1)
        {
            var customers = _context.Customers.OrderBy(x => x.CustomerName).ThenBy(x => x.CustomerSurname).ToList();
            return View(customers.ToPagedList(page, 8));
        }

        public IActionResult CustomerListOrderByDescBalance(int page = 1)
        {
            var customers = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(customers.ToPagedList(page, 8));
        }

        public IActionResult CustomerGetByCity(string city)
        {
            var exists = _context.Customers.Any(x => x.CustomerCity == city);
            if(exists)
            {
                ViewBag.message = $"{city} şehrinde en az 1 müşteri var.";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok.";
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}
