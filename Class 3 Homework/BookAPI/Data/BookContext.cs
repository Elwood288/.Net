using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source =Book.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Grapes of Wrath", Author = "Author 1", Category = "Category 1" },
            new Book { Id = 2, Title = "Cannery Row", Author = "Author 2", Category = "Category 2" },
            new Book { Id = 3, Title = "The Shining", Author = "Author 3", Category = "Category 3" });
        }
    }
}
