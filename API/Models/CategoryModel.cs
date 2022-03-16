using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CategoryCreateModel
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public IEnumerable<BookCreateModel>? Books { get; set; }

    }

    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<BookViewModel>? Books { get; set; }
    }

    public class CategoryEditModel
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }

    }

}
