using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents
{
    public class _SalesStatusDashboardComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _context.Customers.GroupBy(x => x.CustomerCity).Select(o => new CustomerCityChartViewModel
            {
                City = o.Key,
                Count = o.Count()
            }).ToList();
            return View(data);
        }
    }
}
