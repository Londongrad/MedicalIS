using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Diseases.GetAllDiseases
{
    public class GetAllDiseasesQueryHandler(IDiseaseRepository repository)
        : IRequestHandler<GetAllDiseasesQuery, IReadOnlyList<DiseaseDTO>>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<IReadOnlyList<DiseaseDTO>> Handle(GetAllDiseasesQuery request, CancellationToken cancellationToken)
        {
            var diseases = await _repository.GetAllAsync(cancellationToken);

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
