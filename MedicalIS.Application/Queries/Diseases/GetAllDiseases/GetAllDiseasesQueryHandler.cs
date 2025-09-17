using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Diseases.GetAllDiseases
{
    public class GetAllDiseasesQueryHandler(IDiseaseRepository repository, ILogger<GetAllDiseasesQueryHandler> logger)
        : IRequestHandler<GetAllDiseasesQuery, IReadOnlyList<DiseaseDTO>>
    {
        private readonly IDiseaseRepository _repository = repository;
        private readonly ILogger<GetAllDiseasesQueryHandler> _logger = logger;

        public async Task<IReadOnlyList<DiseaseDTO>> Handle(GetAllDiseasesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Выполняется запрос {QueryName}", nameof(GetAllDiseasesQuery));

            var diseases = await _repository.GetAllAsync(cancellationToken);

            _logger.LogDebug("Запрос {QueryName} успешно выполнен. Получено {Count} заболеваний.",
                nameof(GetAllDiseasesQuery), diseases.Count);

            return diseases.Select(d =>
                new DiseaseDTO
                (
                    d.Id,
                    d.Name,
                    d.Description
                ))
                .ToList();
        }
    }
}
