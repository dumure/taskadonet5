using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace taskadonet5
{
    internal class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public LibraryContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
Database=Library; 
Integrated Security=SSPI");
        }
    }
}
