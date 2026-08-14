using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _CardStatisticsDashboardComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.totalCustomerCount = _context.Customers.Count();
            ViewBag.totalCategoryCount = _context.Categories.Count();
            ViewBag.totalProductCount = _context.Products.Count();
            ViewBag.avgCustomerBalance = _context.Customers.Average(x => x.CustomerBalance).ToString("N2");
            ViewBag.totalOrderCount = _context.Orders.Count();
            ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount);
            return View();
        }
    }
}
