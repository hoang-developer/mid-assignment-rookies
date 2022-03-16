using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BookCreateModel
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }

    }

    public class BookViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
    }

}
