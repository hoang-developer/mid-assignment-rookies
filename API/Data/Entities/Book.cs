using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Data.Entities
{
    // [Table("MyTable")] Custom name for table.
    public class Book : BaseEntity
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Summary { get; set; }

        // Relationship
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set;}
        public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }

    }
}