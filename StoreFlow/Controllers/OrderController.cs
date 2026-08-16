using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.Controllers
{
    public class OrderController(StoreContext _context) : Controller
    {
        public IActionResult AllStockSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount < 5);
            if(orderStockCount)
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
            if(!values.Any())
            {
                ViewBag.v = "Bu status ile ilgili veri bulunamadı.";
            }

            return View(values);
        }
    }
}
