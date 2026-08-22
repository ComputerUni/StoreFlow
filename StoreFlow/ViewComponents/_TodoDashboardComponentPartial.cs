using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _TodoDashboardComponentPartial(StoreContext _context) : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            var todos = _context.Todos.OrderBy(t => t.TodoId).Take(6).ToList();
            return View(todos);
        }
    }
}
