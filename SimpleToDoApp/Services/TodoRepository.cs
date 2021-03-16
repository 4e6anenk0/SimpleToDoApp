using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleToDoApp.Data;
using SimpleToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoApp.Services
{
    public class TodoRepository : ITodoRepository
    {
        
        private TodoDbContext db;

        public TodoRepository(TodoDbContext context)
        {
            db = context;
        }
        public void Create(Todo item)
        {
            db.Todos.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Todo todo = db.Todos.Find(id);
            if (todo != null) 
                db.Todos.Remove(todo);
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Todo> GetAllTodos()
        {
            return db.Todos;
        }

        public Todo GetTodo(int id)
        {
            return db.Todos.Find(id);
        }

        public void Update(Todo item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
