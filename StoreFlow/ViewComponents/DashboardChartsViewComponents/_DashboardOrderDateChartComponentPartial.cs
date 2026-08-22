using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents.DashboardChartsViewComponents
{
    public class _DashboardOrderDateChartComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var orders = _context.Orders.GroupBy(o => o.OrderDate.Date).Select(o => new
            {
                RawDate = o.Key,
                Count = o.Count()
            })
            .OrderBy(x => x.RawDate)
            .ToList()
            .Select(o => new OrderDateViewModel
            {
                Date = o.RawDate.ToString("yyyy-MM-dd"),
                Count = o.Count
            }).ToList();

            return View(orders);
        }
    }
}
