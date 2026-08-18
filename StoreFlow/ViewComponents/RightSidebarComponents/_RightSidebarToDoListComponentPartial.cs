using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarToDoListComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderBy(x => x.TodoId).ToList().TakeLast(10).ToList();
            return View(values);
        }
    }
}
