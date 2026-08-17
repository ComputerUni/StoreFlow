using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.Controllers
{
    public class MessageController(StoreContext _context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
