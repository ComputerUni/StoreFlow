using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents.DashboardChartsViewComponents
{
    public class _DashboardOrderStatusChartComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Orders.GroupBy(o => o.Status).Select(o => new OrderStatusChartViewModel
            {
                Status = o.Key,
                Count = o.Count()
            }).ToList();
            return View(values);
        }
    }
}
