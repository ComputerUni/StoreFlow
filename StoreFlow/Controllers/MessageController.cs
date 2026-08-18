using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class MessageController(StoreContext _context) : Controller
    {
        public IActionResult MessageList(int page = 1)
        {
            var messages = _context.Messages.AsNoTracking().ToList();
            return View(messages.ToPagedList(page, 8));
        }
    }
}
