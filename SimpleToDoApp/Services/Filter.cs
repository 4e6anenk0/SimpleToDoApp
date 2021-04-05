using SimpleToDoApp.Data;
using SimpleToDoApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoApp.Services
{
    public class Filter
    {
        private TodoDbContext db;

        public Filter(TodoDbContext context)
        {
            db = context;
        }

        public IEnumerable<Todo> GetTomorrowTodos()
        {
            DateTime today = DateTime.Today;
            IEnumerable<Todo> queryable = from t in db.Todos
                                   where 
                                   t.EndData != null && 
                                   t.EndData >= today.AddHours(24) && 
                                   t.EndData <= today.AddHours(48)
                                   select t;
            return queryable;
        }

        public IEnumerable<Todo> GetTodayTodos()
        {
            DateTime today = DateTime.Today;
            IEnumerable<Todo> queryable = from t in db.Todos
                                          where
                                          t.EndData != null &&
                                          t.EndData >= today &&
                                          t.EndData <= today.AddHours(24)
                                          select t;
            return queryable;
        }

        public IEnumerable<Todo> GetWeekTodos()
        {
            DateTime today = DateTime.Today;
            IEnumerable<Todo> queryable = from t in db.Todos
                                          where
                                          t.EndData != null &&
                                          t.EndData >= today &&
                                          t.EndData <= today.AddDays(7)
                                          select t;
            return queryable;
        }
    }
}
