using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services
{
    public interface IUniversityService
    {
        Task<IReadOnlyCollection<UniversityDTO>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<UniversityDTO> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task<UniversityDTO> AddAsync(
            CreateUniversityRequest request,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default);
    }
}