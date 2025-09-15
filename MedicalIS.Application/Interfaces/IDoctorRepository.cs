using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Interfaces
{
    /// <summary>Определяет контракт репозитория для работы с сущностями <see cref="Doctor"/>.</summary>
    public interface IDoctorRepository
    {
        /// <summary>Получает сущность <see cref="Doctor"/> по её идентификатору.</summary>
        /// <returns>Экземпляр <see cref="Doctor"/>.</returns>
        /// <exception cref="NotFoundException">
        /// Выбрасывается, если доктор с указанным <paramref name="id"/> не найден.
        /// </exception>
        Task<Doctor> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>Возвращает неотслеживаемую коллекцию всех докторов.</summary>
        /// <returns>Коллекция <see cref="IReadOnlyList{Doctor}"/>.</returns>
        Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>Возвращает коллекцию докторов по указанной специальности.</summary>
        /// <returns>Коллекция <see cref="IReadOnlyList{Doctor}"/>.</returns>
        Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(Specialty specialty, CancellationToken cancellationToken = default);

        /// <summary>Добавляет нового доктора в контекст отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default);

        /// <summary>Обновляет существующего доктора в контексте отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        void Update(Doctor doctor);

        /// <summary>Удаляет доктора из контекста отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        void Remove(Doctor doctor);
    }
}
