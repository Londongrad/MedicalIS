using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Interfaces
{
    public interface IDiseaseRepository
    {
        /// <summary>Возвращает неотслеживаемую коллекцию всех болезней.</summary>
        /// <returns>Экземпляр <see cref="IReadOnlyList{Disease}"/>.</returns>
        Task<IReadOnlyList<Disease>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>Получает сущность <see cref="Disease"/> по её идентификатору.</summary>
        /// <returns>Экземпляр <see cref="Disease"/>.</returns>
        /// <exception cref="NotFoundException">
        /// Выбрасывается, если болезнь с указанным <paramref name="id"/> не найдена.
        /// </exception>
        Task<Disease> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
