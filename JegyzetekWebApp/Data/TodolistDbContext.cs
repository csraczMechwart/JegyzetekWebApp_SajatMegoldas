using JegyzetekWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JegyzetekWebApp.Data
{
    public class TodolistDbContext : DbContext
    {
        public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
        {
            
        }
        public DbSet<Kartya> Kartyak { get; set; }
        public DbSet<Teendo> Teendok { get; set; }
    }
}
