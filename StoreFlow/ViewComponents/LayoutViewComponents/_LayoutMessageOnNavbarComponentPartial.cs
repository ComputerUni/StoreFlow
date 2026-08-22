using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.LayoutViewComponents
{
    public class _LayoutMessageOnNavbarComponentPartial(StoreContext _context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(m => m.IsRead == false).OrderByDescending(m => m.MessageId).Take(3).ToList();
            ViewBag.messages = _context.Messages.Where(x => x.IsRead == false).Count();
            return View(values);
        }
    }
}
