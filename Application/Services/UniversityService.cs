using Application.CustomExceptions;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Models;

namespace Application.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityService(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<IReadOnlyCollection<UniversityDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var universities =
                await _universityRepository.GetAllAsync(cancellationToken);

            return universities
                .Select(MapToDto)
                .ToList();
        }

        public async Task<UniversityDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var university =
                await _universityRepository.GetByIdAsync(
                    id,
                    cancellationToken);

            if (university is null)
            {
                throw new NotFoundException(
                    $"University with id {id} was not found.");
            }

            return MapToDto(university);
        }

        public async Task<UniversityDTO> AddAsync(CreateUniversityRequest request, CancellationToken cancellationToken = default)
        {
            var university = new University
            {
                Name = request.Name.Trim()
            };

            await _universityRepository.AddAsync(
                university,
                cancellationToken);

            return MapToDto(university);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var university =
                await _universityRepository.GetByIdAsync(
                    id,
                    cancellationToken);

            if (university is null)
            {
                throw new NotFoundException(
                    $"University with id {id} was not found.");
            }

            await _universityRepository.DeleteAsync(
                university,
                cancellationToken);
        }

        private static UniversityDTO MapToDto(University university)
        {
            return new UniversityDTO
            {
                Id = university.Id,
                Name = university.Name,

                Faculties = university.Faculties
                    .OrderBy(faculty => faculty.Name)
                    .Select(faculty => new FacultyDTO
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
                    })
                    .ToList()
            };
        }
    }
}