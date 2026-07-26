using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class University
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        public List<Faculty>? Faculties { get; set; }
    }
}