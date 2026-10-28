using System.Collections.Generic;

namespace Entity.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}
