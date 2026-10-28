using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Navigation property for 1-to-many relationship by convention
        public List<Book> Books { get; set; } = new();
    }
}
