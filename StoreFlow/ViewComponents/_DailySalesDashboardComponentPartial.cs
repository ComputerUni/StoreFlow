using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents
{
    public class _DailySalesDashboardComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _context.Todos.GroupBy(x => x.Priority).Select(g => new TodoStatusChartViewModel
            {
                Priority = g.Key,
                Count = g.Count()
            }).ToList();
            return View(data);
        }
    }
}
