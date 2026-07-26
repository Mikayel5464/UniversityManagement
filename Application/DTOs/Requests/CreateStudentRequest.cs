using System.ComponentModel.DataAnnotations;
using Application.Models;

namespace Application.DTOs.Requests
{
    public class CreateStudentRequest
    {
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