using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IReadOnlyCollection<StudentDTO>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<StudentDTO> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default);

        Task<StudentDTO> AddAsync(
            CreateStudentRequest request,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default);
    }
}