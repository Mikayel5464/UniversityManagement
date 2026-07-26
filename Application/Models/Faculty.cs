using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Faculty
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public University? University { get; set; }
        public List<Student>? Students { get; set; }
    }
}