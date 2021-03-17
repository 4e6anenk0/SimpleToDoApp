using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleToDoApp.Data;
using SimpleToDoApp.Models;
using SimpleToDoApp.Services;
using System.Diagnostics;

namespace SimpleToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        TodoRepository db;

        public HomeController(ILogger<HomeController> logger, TodoDbContext context)
        {
            _logger = logger;
            db = new TodoRepository(context);
        }

        public IActionResult Index()
        {
            return View(db.GetAllTodos());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            db.Create(todo);           
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    return View(db.GetTodo(id));
        //}

        //[HttpPost]
        //public IActionResult Edit(Todo todo)
        //{
        //    db.Update(todo);
        //    return RedirectToAction("Index");
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
