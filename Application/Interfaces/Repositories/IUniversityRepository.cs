using Application.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUniversityRepository
    {
        Task<IReadOnlyCollection<University>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<University?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            University university,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            University university,
            CancellationToken cancellationToken = default);
    }
}