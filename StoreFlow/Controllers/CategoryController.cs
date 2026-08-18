using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class CategoryController(StoreContext _context) : Controller
    {
        public IActionResult CategoryList(int page = 1)
        {
            var categories = _context.Categories.ToList();
            return View(categories.ToPagedList(page, 8));
        }

        public IActionResult ChangeStatus(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                category.CategoryStatus = !category.CategoryStatus;
                _context.SaveChanges();
            }

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public IActionResult ReverseCategory(int page = 1)
        {
            var categoryValue = _context.Categories.First();
            ViewBag.v = categoryValue.CategoryName;

            var categoryValue2 = _context.Categories.SingleOrDefault(x => x.CategoryName == "Ev Aletleri");
            ViewBag.v2 = categoryValue2.CategoryStatus + " " + categoryValue2.CategoryId;

            var values = _context.Categories.OrderBy(x => x.CategoryId).ToList();
            values.Reverse();
            return View(values.ToPagedList(page, 8));
        }
    }
}
