using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using API.Data.Entities;

namespace API.Data.Entities
{
   
        public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string? Username { get; set; }
        [Required, MaxLength(50)]
        public string? Password { get; set; }
        public bool? isSuperUser { get; set; }
        public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
        public ICollection<BookBorrowingRequest>? ProcessedRequests { get; set; }

    }
}
