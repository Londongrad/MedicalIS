using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;

namespace MedicalIS.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(string specialty, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
