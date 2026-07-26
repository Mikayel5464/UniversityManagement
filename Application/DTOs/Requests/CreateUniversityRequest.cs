using System.ComponentModel.DataAnnotations;
using Application.Models;

namespace Application.DTOs.Requests
{
    public class CreateUniversityRequest
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        
        public List<Faculty>? Faculties { get; set; }
    }
}