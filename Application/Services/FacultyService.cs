using Application.CustomExceptions;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models;

namespace Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUniversityRepository _universityRepository;

        public FacultyService(
            IFacultyRepository facultyRepository,
            IUniversityRepository universityRepository)
        {
            _facultyRepository = facultyRepository;
            _universityRepository = universityRepository;
        }

        public async Task<IReadOnlyCollection<FacultyDTO>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var faculties =
                await _facultyRepository.GetAllAsync(cancellationToken);

            return faculties
                .Select(MapToDto)
                .ToList();
        }

        public async Task<FacultyDTO> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            var faculty =
                await _facultyRepository.GetByIdAsync(
                    id,
                    cancellationToken);

            if (faculty is null)
            {
                throw new NotFoundException(
                    $"Faculty with id {id} was not found.");
            }

            return MapToDto(faculty);
        }

        public async Task<FacultyDTO> AddAsync(
            CreateFacultyRequest request,
            CancellationToken cancellationToken = default)
        {
            var university =
                await _universityRepository.GetByIdAsync(
                    request.University.Id,
                    cancellationToken);

            if (university is null)
            {
                throw new NotFoundException(
                    $"University with id {request.University.Id} was not found.");
            }

            var faculty = new Faculty
            {
                Name = request.Name.Trim(),
                University = new University
                {
                    Id = request.University.Id,
                    Name = request.Name,
                    Faculties = request.University.Faculties
                }
            };

            await _facultyRepository.AddAsync(
                faculty,
                cancellationToken);

            return await GetByIdAsync(
                faculty.Id,
                cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var faculty = await _facultyRepository.GetByIdAsync(id, cancellationToken);

            if (faculty is null)
            {
                throw new NotFoundException(
                    $"Faculty with id {id} was not found.");
            }

            await _facultyRepository.DeleteAsync(faculty, cancellationToken);
        }

        private static FacultyDTO MapToDto(Faculty faculty)
        {
            return new FacultyDTO
            {
                Id = faculty.Id,
                Name = faculty.Name,
                UniversityId = faculty.University.Id,

                Students = faculty.Students
                    .OrderBy(student => student.LastName)
                    .ThenBy(student => student.FirstName)
                    .Select(student => new StudentDTO
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Age = student.Age,
                        FacultyId = student.Faculty.Id
                    })
                    .ToList()
            };
        }
    }
}