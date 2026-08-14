using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.Controllers
{
    public class TodoController(StoreContext _context) : Controller
    {
        [HttpPost]
        public IActionResult UpdateStatus(int id)
        {
            var todo = _context.Todos.Find(id);

            if(todo != null)
            {
                todo.Status = !todo.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);

            if(todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
