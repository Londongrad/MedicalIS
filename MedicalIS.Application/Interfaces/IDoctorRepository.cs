using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(string specialty, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
