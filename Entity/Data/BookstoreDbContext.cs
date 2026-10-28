using Microsoft.EntityFrameworkCore;
using Entity.Models;

namespace Entity.Data
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ReadMoreBooksDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

    }
}
