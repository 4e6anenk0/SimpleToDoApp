using SimpleToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoApp.Services
{
    interface ITodoRepository : IDisposable
    {
        IEnumerable<Todo> GetAllTodos();
        Todo GetTodo(int id);
        void Update(Todo item);
        void Create(Todo item);
        void Delete(int id);
        void Save();
    }
}
