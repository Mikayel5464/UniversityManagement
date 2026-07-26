using System.ComponentModel.DataAnnotations;
using Application.Models;

namespace Application.DTOs.Requests
{
    public class CreateFacultyRequest
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
        public University? University { get; set; }
        public List<Student>? Students { get; set; }
    }
}