using Application.Models;

namespace Application.Interfaces.Repositories
{
    public interface IFacultyRepository
    {
        Task<IReadOnlyCollection<Faculty>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<Faculty?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Faculty faculty,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Faculty faculty,
            CancellationToken cancellationToken = default);
    }
}