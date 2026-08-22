using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class ActivityController(StoreContext _context) : Controller
    {
        public IActionResult ActivityList(int page = 1)
        {
            var activities = _context.Activities.ToList();
            return View(activities.ToPagedList(page, 8));
        }

        [HttpGet]
        public IActionResult CreateActivity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return RedirectToAction("ActivityList");
        }

        [HttpGet]
        public IActionResult UpdateActivity(int id)
        {
            var activity = _context.Activities.Find(id);
            return View(activity);
        }


        [HttpPost]
        public IActionResult UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
            return RedirectToAction("ActivityList");
        }

        public IActionResult DeleteActivity(int id)
        {
            var activity = _context.Activities.Find(id);
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return RedirectToAction("ActivityList");
        }
    }
}
