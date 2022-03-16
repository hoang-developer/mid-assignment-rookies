using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities
{
    public class BookBorrowingRequest : BaseEntity
    {
        [Required]
        public int RequestedByUserId { get; set; }
        public virtual User? RequestedBy { get; set; }
        [Required, DefaultValue(RequestStatus.Waiting)]
        public RequestStatus Status { get; set; }
        public DateTime DateRequested { get; set; }
        public int? StatusUpdateByUserId { get; set; }
        public virtual User? StatusUpdateBy { get; set; }
        public ICollection<BookBorrowingRequestDetails>? RequestDetails { get; set; }
    }
}