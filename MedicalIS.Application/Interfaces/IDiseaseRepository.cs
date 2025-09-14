using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<IReadOnlyList<Disease>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
