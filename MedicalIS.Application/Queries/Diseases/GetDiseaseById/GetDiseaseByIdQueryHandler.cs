using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using MedicalIS.Application.Queries.Diseases.GetAllDiseases;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Diseases.GetDiseaseById
{
    public class GetDiseaseByIdQueryHandler(IDiseaseRepository repository, ILogger<GetAllDiseasesQueryHandler> logger)
        : IRequestHandler<GetDiseaseByIdQuery, DiseaseDTO>
    {
        private readonly IDiseaseRepository _repository = repository;
        private readonly ILogger<GetAllDiseasesQueryHandler> _logger = logger;
        public async Task<DiseaseDTO> Handle(GetDiseaseByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполняется запрос {QueryName} для болезни с Id = {DiseaseId}",
                nameof(GetDiseaseByIdQuery), request.Id);

            var disease = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return new DiseaseDTO
            (
                disease.Id,
                disease.Name,
                disease.Description
            );
        }
    }
}
