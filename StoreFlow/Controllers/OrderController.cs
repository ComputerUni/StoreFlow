using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class OrderController(StoreContext _context) : Controller
    {
        public IActionResult AllStockSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount < 5);
            if (orderStockCount)
            {
                ViewBag.v = "Tüm siparişler 5 adetten küçüktür.";
            }
            else
            {
                ViewBag.v = "Tüm siparişler 5 adetten küçük değildir.";
            }
            return View(orderStockCount);
        }

        public IActionResult OrderListByStatus(string status)
        {
            var values = _context.Orders.Include(x => x.Customer).Include(x => x.Product).Where(x => x.Status.Contains(status)).ToList();
            if (!values.Any())
            {
                ViewBag.v = "Bu status ile ilgili veri bulunamadı.";
            }

            return View(values);
        }

        public IActionResult OrderListSearch(string name, string filterType)
        {
            if (filterType == "start")
            {
                var values = _context.Orders.Include(x => x.Customer).Include(x => x.Product).Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (filterType == "end")
            {
                var values = _context.Orders.Include(x => x.Customer).Include(x => x.Product).Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }

            var orders = _context.Orders.Include(x => x.Customer).Include(x => x.Product).ToList();

            return View(orders);
        }

        public async Task<IActionResult> OrderListAsync2(int page = 1)
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values.ToPagedList(page, 8));
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products = await _context.Products.Select(p => new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.ProductName
            }).ToListAsync();

            ViewBag.products = products;

            var customers = await _context.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.CustomerName + " " + c.CustomerSurname
            }).ToListAsync();

            ViewBag.customers = customers;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Sipariş Alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderListAsync2");
        }
    }
}
