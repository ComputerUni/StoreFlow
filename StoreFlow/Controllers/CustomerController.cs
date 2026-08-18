using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;
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

        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers.ToList().GroupBy(c => c.CustomerCity).ToList();
            return View(groupedCustomers);
        }

        public IActionResult CustomersByCityCount()
        {
            var query = from c in _context.Customers
                        group c by c.CustomerCity into cityGroup
                        //şehrin sayısına göre filtrelemek için
                        orderby cityGroup.Count() descending
                        select new CustomerCityGroup
                        {
                            City = cityGroup.Key,
                            CustomerCount = cityGroup.Count()
                        };

            var model = query.ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }

        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result = customers.AsParallel().Where(c => c.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
            return View(result);
        }

        public IActionResult CustomerListExceptCityIstanbul(int page = 1)
        {
            var allCustomers = _context.Customers.ToList();
            var customersListInIstanbul = _context.Customers.Where(x => x.CustomerCity == "İstanbul").Select(x => x.CustomerCity).ToList();
            var result = allCustomers.ExceptBy(customersListInIstanbul, c => c.CustomerCity).ToList();
            return View(result.ToPagedList(page, 7));
        }

        public IActionResult CustomerListWithDefaultIfEmpty(int page = 1)
        {
            var customers = _context.Customers.Where(x => x.CustomerCity == "fdsfsd").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName = "Kayıt Yok",
                CustomerSurname = "----",
                CustomerCity = "Malatya"
            }).ToList();

            return View(customers.ToPagedList(page, 8));
        }

        public IActionResult CustomerIntersectByCity()
        {
            var cityValues = _context.Customers.Where(x => x.CustomerCity == "Balıkesir").Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var cityValues2 = _context.Customers.Where(x => x.CustomerCity == "Ankara").Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var intersectValues = cityValues.Intersect(cityValues2).ToList();
            return View(intersectValues);
        }

        public IActionResult CustomerCastExample()
        {
            var values = _context.Customers.ToList();
            ViewBag.v = values;
            return View();
        }
    }
}
