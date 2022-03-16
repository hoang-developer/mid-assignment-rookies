using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class BookBorrowingRequestDetails : BaseEntity
    {
        [Required]
        public int BookBorrowingRequestId { get; set; }
        public virtual BookBorrowingRequest? BookBorrowingRequest { get; set; }
        [Required]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}