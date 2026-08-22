using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
