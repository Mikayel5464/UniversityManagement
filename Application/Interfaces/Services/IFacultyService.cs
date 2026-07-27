using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services
{
    public interface IFacultyService
    {
        Task<IReadOnlyCollection<FacultyDTO>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<FacultyDTO> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<FacultyDTO> AddAsync(
            CreateFacultyRequest request,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}