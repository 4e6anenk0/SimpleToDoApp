using SimpleToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TodoDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Todos.Any())
            {
                return;
            }

            var todos = new Todo[]
            {
                new Todo{IsDone=false, Text="Очередное задание", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание2", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3. Больше текста, еше больше текста, больше текста. Намного больше текста", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3. Балалалалалалалала блала блаал балал", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3", EndData=DateTime.Parse("2021-09-01")},
                new Todo{IsDone=false, Text="Очередное задание3", EndData=DateTime.Parse("2021-09-01")}
            };

            context.Todos.AddRange(todos);
            context.SaveChanges();

            var labels = new Label[]
            {
                new Label{LabelText="Важное", Priority=1},
                new Label{LabelText="Работа", Priority=2},
                new Label{LabelText="Развитие", Priority=3}
            };

            context.Labels.AddRange(labels);
            context.SaveChanges();

            var colors = new ColorData[]
            {
                new ColorData{Name="Зеленый", Argb=Color.Green.ToArgb() },
                new ColorData{Name="Красный", Argb=Color.Red.ToArgb() },
                new ColorData{Name="Синий", Argb=Color.Blue.ToArgb() }
            };

            context.Colors.AddRange(colors);
            context.SaveChanges();


        }
    }
}
