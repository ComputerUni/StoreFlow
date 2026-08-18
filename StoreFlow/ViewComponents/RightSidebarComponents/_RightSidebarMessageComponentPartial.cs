using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.RightSidebarComponents
{
    public class _RightSidebarMessageComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }
    }
}
