using MedicalIS.Application.Interfaces;

namespace MedicalIS.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        /// <summary>Сохраняет все изменения, сделанные в текущем контексте.</summary>
        /// <returns>Количество изменённых записей в базе данных.</returns>
        /// <remarks>
        /// Метод фиксирует изменения, сделанные через репозитории. 
        /// Вызывать его необходимо вручную после операций <c>AddAsync</c>, <c>Update</c> и <c>Remove</c>.
        /// </remarks>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
