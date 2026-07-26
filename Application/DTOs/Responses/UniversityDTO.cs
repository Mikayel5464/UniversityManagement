namespace Application.DTOs.Responses
{
    public class UniversityDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<FacultyDTO>? Faculties { get; set; }
    }
}