using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using X.PagedList.Extensions;

namespace StoreFlow.Controllers
{
    public class TodoController(StoreContext _context) : Controller
    {
        public IActionResult Index(int page = 1)
        {
            int pageSize = 8;
            var todos = _context.Todos.ToList().ToPagedList(page,pageSize);
            return View(todos);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo != null)
            {
                todo.Status = !todo.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateTodo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTodo(Todo todo)
        {
            todo.Status = false;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public IActionResult UpdateTodo(int id)
        {
            var todo = _context.Todos.Find(id);
            return View(todo);
        }

        [HttpPost] 
        public IActionResult UpdateTodo(Todo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateTodo()
        //{
        //    var todos = new List<Todo>
        //    {
        //        new Todo {Description = "Mail gönder", Status = true, Priority = "Birincil"},
        //        new Todo {Description = "Rapor hazırla", Status = true, Priority = "İkincil"},
        //        new Todo{Description = "Toplantıya katıl", Status = false, Priority = "Birincil"}
        //    };

        //    await _context.Todos.AddRangeAsync(todos);
        //    await _context.SaveChangesAsync();

        //    return View();
        //}

        public IActionResult TodoAggreagatePriority()
        {
            var priorityFirstlyTodo = _context.Todos.Where(x => x.Priority == "Birincil").Select(y => y.Description).ToList();
            //string result = priorityFirstlyTodo.Aggregate((acc, desc) => acc + ", " + desc);
            //ViewBag.results = result;
            return View(priorityFirstlyTodo);
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos.Where(t => !t.Status).Select(x => x.Description).ToList().Prepend("Gün başında tüm görevleri kontrol etmeyi unutmayın!").ToList();
            return View(values);
        }

        public IActionResult TodoChunk()
        {
            var values = _context.Todos.Where(x => !x.Status).ToList().Chunk(2).ToList();
            return View(values);
        }

        public IActionResult TodoConcat()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList().Concat(_context.Todos.Where(x => x.Priority == "İkincil").ToList()).ToList();
            return View(values);
        }

        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList();
            var values2 = _context.Todos.Where(x => x.Priority == "İkincil").ToList();
            var result = values.UnionBy(values2, x => x.Description).ToList();
            return View(result);
        }

        public IActionResult ChangeStatus(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo != null)
            {
                todo.Status = !todo.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
