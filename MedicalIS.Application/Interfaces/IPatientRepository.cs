using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Interfaces
{
    /// <summary>Определяет контракт репозитория для работы с сущностями <see cref="Patient"/>.</summary>
    public interface IPatientRepository
    {
        /// <summary>Получает сущность <see cref="Patient"/> по её идентификатору.</summary>
        /// <returns>Экземпляр <see cref="Patient"/>.</returns>
        /// <exception cref="NotFoundException">
        /// Выбрасывается, если пациент с указанным <paramref name="id"/> не найден.
        /// </exception>
        Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>Возвращает неотслеживаемую коллекцию всех пациентов.</summary>
        /// <returns>Экземпляр <see cref="IReadOnlyList{Patient}"/>.</returns>
        Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>Добавляет нового пациента в контекст отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        Task AddAsync(Patient patient, CancellationToken cancellationToken = default);

        /// <summary>Обновляет существующего пациента в контексте отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        void Update(Patient patient);

        /// <summary>Удаляет пациента из контекста отслеживания.</summary>
        /// <remarks>
        /// Метод <b>не выполняет сохранение в базе данных</b>. 
        /// Для фиксации изменений необходимо вызвать <see cref="IUnitOfWork.SaveChangesAsync"/>.
        /// </remarks>
        void Remove(Patient patient);
    }
}
