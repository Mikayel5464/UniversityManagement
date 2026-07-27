using Application.CustomExceptions;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IFacultyRepository facultyRepository)
        {
            _studentRepository = studentRepository;
            _facultyRepository = facultyRepository;
        }

        public async Task<IReadOnlyCollection<StudentDTO>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var students =
                await _studentRepository.GetAllAsync(cancellationToken);

            return students
                .Select(MapToDto)
                .ToList();
        }

        public async Task<StudentDTO> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var student =
                await _studentRepository.GetByIdAsync(
                    id,
                    cancellationToken);

            if (student is null)
            {
                throw new NotFoundException(
                    $"Student with id {id} was not found.");
            }

            return MapToDto(student);
        }

        public async Task<StudentDTO> AddAsync(
            CreateStudentRequest request,
            CancellationToken cancellationToken = default)
        {
            var faculty =
                await _facultyRepository.GetByIdAsync(
                    request.Faculty.Id,
                    cancellationToken);

            if (faculty is null)
            {
                throw new NotFoundException(
                    $"Faculty with id {request.Faculty.Id} was not found.");
            }

            var student = new Student
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Age = request.Age,
                Faculty = new Faculty
                {
                    Id = request.Faculty.Id,
                    Name = request.Faculty.Name,
                    University = request.Faculty.University,
                    Students = request.Faculty.Students
                }
            };

            await _studentRepository.AddAsync(
                student,
                cancellationToken);

            return MapToDto(student);
        }

        public async Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var student =
                await _studentRepository.GetByIdAsync(
                    id,
                    cancellationToken);

            if (student is null)
            {
                throw new NotFoundException(
                    $"Student with id {id} was not found.");
            }

            await _studentRepository.DeleteAsync(
                student,
                cancellationToken);
        }

        private static StudentDTO MapToDto(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                FacultyId = student.Faculty.Id
            };
        }
    }
}
