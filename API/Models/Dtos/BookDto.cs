using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using API.Data.Entities;

namespace API.Models.Dtos
{
    public class BookCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public int CategoryId { get; set; }
        // public virtual Category? Category { get; set;}
    }
    public class BookViewDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        public virtual Category? Category { get; set;}
        // public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }
    }
    public class BookEditDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }
        // public virtual Category? Category { get; set;}
    }
}
