using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : IDoctorRepository
    {
        private readonly ApplicationDbContext _context = context;

        /// <summary>Добавляет нового доктора в контекст отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public async Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            await _context.Doctors.AddAsync(doctor, cancellationToken);
        }

        /// <summary>Возвращает неотслеживаемую коллекцию всех докторов.</summary>
        /// <returns>Коллекция <see cref="IReadOnlyList{Doctor}"/>.</returns>
        public async Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <summary>Получает сущность <see cref="Doctor"/> по её идентификатору.</summary>
        /// <returns>Экземпляр <see cref="Doctor"/>.</returns>
        /// <exception cref="NotFoundException">
        /// Выбрасывается, если доктор с указанным <paramref name="id"/> не найден.
        /// </exception>
        public async Task<Doctor> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Doctor), id);
        }

        /// <summary>Возвращает коллекцию докторов по указанной специальности.</summary>
        /// <returns>Коллекция <see cref="IReadOnlyList{Doctor}"/>.</returns>
        public async Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(Specialty specialty, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .Where(d => d.Specialty == specialty)
                .ToListAsync(cancellationToken);
        }

        /// <summary>Обновляет существующего доктора в контексте отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        /// <summary>Удаляет доктора из контекста отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        public void Remove(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}
