using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class DiseaseRepository(ApplicationDbContext dbContext) : IDiseaseRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        /// <inheritdoc/>
        public async Task<IReadOnlyList<Disease>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Diseases
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Disease> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Diseases
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Doctor), id);
        }
    }
}
