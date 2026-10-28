using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entity.Data;
using Entity.Models;

namespace Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReadMore Books - Database Initialization");

            using (var context = new BookstoreDbContext())
            {
                Console.WriteLine("Recreating database 'ReadMoreBooksDb' using EF Core conventions...");
                context.Database.EnsureDeleted();
                bool isCreated = context.Database.EnsureCreated();

                if (isCreated)
                {
                    Console.WriteLine("Database and tables created successfully");
                }
                else
                {
                    Console.WriteLine("Database already exists or was verified");
                }

                var sciFiCategory = new Category
                {
                    Name = "Science Fiction",
                    Description = "Speculative fiction dealing with imaginative concepts such as advanced science and technology.",
                    IsActive = true
                };

                var classicCategory = new Category
                {
                    Name = "Classic Literature",
                    Description = "Works of literature that have stood the test of time and remain culturally significant.",
                    IsActive = true
                };

                var orwell = new Author
                {
                    FirstName = "George",
                    LastName = "Orwell",
                    Email = "george.orwell@readmorebooks.example.com",
                    Biography = "English novelist, essayist, journalist, and critic whose work is marked by lucid prose and social criticism.",
                    DateOfBirth = new DateTime(1903, 6, 25)
                };

                var herbert = new Author
                {
                    FirstName = "Frank",
                    LastName = "Herbert",
                    Email = "frank.herbert@readmorebooks.example.com",
                    Biography = "American science-fiction author best known for the 1965 novel Dune and its five sequels.",
                    DateOfBirth = new DateTime(1920, 10, 8)
                };

                var book1 = new Book
                {
                    Title = "1984",
                    Isbn = "978-0451524935",
                    Price = 14.99m,
                    NumberOfPages = 328,
                    PublicationYear = 1949,
                    IsInStock = true,
                    Author = orwell,
                    Category = classicCategory
                };

                var book2 = new Book
                {
                    Title = "Animal Farm",
                    Isbn = "978-0451526342",
                    Price = 9.99m,
                    NumberOfPages = 140,
                    PublicationYear = 1945,
                    IsInStock = true,
                    Author = orwell,
                    Category = classicCategory
                };

                var book3 = new Book
                {
                    Title = "Dune",
                    Isbn = "978-0441172719",
                    Price = 19.99m,
                    NumberOfPages = 896,
                    PublicationYear = 1965,
                    IsInStock = false,
                    Author = herbert,
                    Category = sciFiCategory
                };

                context.Categories.AddRange(sciFiCategory, classicCategory);
                context.Authors.AddRange(orwell, herbert);
                context.Books.AddRange(book1, book2, book3);

                context.SaveChanges();
                Console.WriteLine("Data successfully inserted into SQL Server");

                Console.WriteLine("ReadMore Books Inventory Query");

                var books = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .ToList();

                foreach (var b in books)
                {
                    Console.WriteLine($"Book ID        : {b.Id}");
                    Console.WriteLine($"Title          : {b.Title}");
                    Console.WriteLine($"ISBN           : {b.Isbn}");
                    Console.WriteLine($"Price          : ${b.Price:F2}");
                    Console.WriteLine($"Pages          : {b.NumberOfPages}");
                    Console.WriteLine($"Published Year : {b.PublicationYear}");
                    Console.WriteLine($"In Stock       : {(b.IsInStock ? "Yes" : "No")}");
                    Console.WriteLine($"Author         : {b.Author.FirstName} {b.Author.LastName} ({b.Author.Email})");
                    Console.WriteLine($"Author Bio     : {b.Author.Biography}");
                    Console.WriteLine($"Author DOB     : {b.Author.DateOfBirth:yyyy-MM-dd}");
                    Console.WriteLine($"Category       : {b.Category.Name} (Active: {(b.Category.IsActive ? "Yes" : "No")})");
                    Console.WriteLine($"Category Desc  : {b.Category.Description}");
                    Console.WriteLine(new string('-', 50));
                }

                Console.WriteLine("All entities and relationships resolved properly");
            }
        }
    }
}
