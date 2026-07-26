namespace Application.DTOs.Responses
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public Guid FacultyId { get; set; }
    }
}