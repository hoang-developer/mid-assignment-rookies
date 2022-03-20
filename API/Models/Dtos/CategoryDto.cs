using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using API.Data.Entities;

namespace API.Models.Dtos
{
    public class CategoryCreateDto
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        public IEnumerable<BookCreateDto>? Books { get; set; }
    }
    public class CategoryViewDto
    {
       public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<BookViewDto>? Books { get; set; }
    }
    public class CategoryEditDto
    {
      [Required, MaxLength(50)]
        public string? Name { get; set; }

    }
}
