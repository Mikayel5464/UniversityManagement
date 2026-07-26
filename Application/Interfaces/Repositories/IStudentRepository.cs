using Application.Models;

namespace Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IReadOnlyCollection<Student>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<Student?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Student student,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Student student,
            CancellationToken cancellationToken = default);
    }
}