using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.LayoutViewComponents
{
    public class _LayoutTodoOnNavbarComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var todos = _context.Todos.Where(x => x.Status == false).OrderByDescending(x => x.TodoId).Take(5).ToList();
            ViewBag.todoTotalCount = _context.Todos.Where(x => x.Status == true).Count();
            return View(todos);
        }
    }
}
