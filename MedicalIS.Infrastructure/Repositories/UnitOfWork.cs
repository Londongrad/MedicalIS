using MedicalIS.Application.Interfaces;

namespace MedicalIS.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
