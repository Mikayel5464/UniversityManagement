namespace Application.DTOs.Responses
{
    public class FacultyDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid UniversityId { get; set; }
        public List<StudentDTO>? Students { get; set; }
    }
}