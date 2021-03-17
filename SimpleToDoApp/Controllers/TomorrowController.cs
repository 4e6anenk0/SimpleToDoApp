using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleToDoApp.Data;
using SimpleToDoApp.Services;


namespace SimpleToDoApp.Controllers
{
    public class TomorrowController : Controller
    {
        private readonly ILogger<TomorrowController> _logger;
        Filter filter;
        TodoRepository db;

        public TomorrowController(ILogger<TomorrowController> logger, TodoDbContext context)
        {
            _logger = logger;
            filter = new Filter(context);
            db = new TodoRepository(context);
        }

        public IActionResult Index()
        {
            return View(filter.GetTomorrowTodos());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
