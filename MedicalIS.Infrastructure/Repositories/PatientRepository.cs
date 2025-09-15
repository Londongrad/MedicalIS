using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        private readonly ApplicationDbContext _context = context;

        /// <summary>Добавляет нового пациента в контекст отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            await _context.Patients.AddAsync(patient, cancellationToken);
        }

        /// <summary>Возвращает неотслеживаемую коллекцию всех пациентов.</summary>
        /// <returns>Экземпляр <see cref="IReadOnlyList{Patient}"/>.</returns>
        public async Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Patients.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>Получает пациента по его идентификатору.</summary>
        /// <returns>Экземпляр <see cref="Patient"/>.</returns>
        /// <exception cref="NotFoundException">
        /// Выбрасывается, если пациент с указанным <paramref name="id"/> не найден.
        /// </exception>
        public async Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Patient), id);
        }

        /// <summary>Обновляет существующего пациента в контексте отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        /// <summary>Удаляет пациента из контекста отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}
