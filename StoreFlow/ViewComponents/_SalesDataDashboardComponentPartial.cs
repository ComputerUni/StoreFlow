using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _SalesDataDashboardComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Orders.Include(x => x.Customer).Include(x => x.Product).OrderByDescending(x => x.OrderDate).Take(5).ToList();
            return View(values);
        }
    }
}
