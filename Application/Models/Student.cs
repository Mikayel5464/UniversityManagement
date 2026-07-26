using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string? LastName { get; set; }
        
        [Required]
        public Faculty? Faculty { get; set; }
    }
}