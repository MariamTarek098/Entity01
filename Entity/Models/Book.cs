namespace Entity.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public int PublicationYear { get; set; }
        public bool IsInStock { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
