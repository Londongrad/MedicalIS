using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(Specialty specialty, CancellationToken cancellationToken = default);
        Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
