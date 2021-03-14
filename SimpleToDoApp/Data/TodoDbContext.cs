using Microsoft.EntityFrameworkCore;
using SimpleToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDoApp.Data

{
    public class TodoDbContext : DbContext 
    {

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<ColorData> Colors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Todo>().ToTable("Todo");
        //    modelBuilder.Entity<Label>().ToTable("Label");
        //    modelBuilder.Entity<ColorData>().ToTable("Color");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=tododb;Trusted_Connection=True;");

    }
}
