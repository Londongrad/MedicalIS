using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Diseases.GetDiseaseById
{
    public class GetDiseaseByIdQueryHandler(IDiseaseRepository repository) 
        : IRequestHandler<GetDiseaseByIdQuery, DiseaseDTO>
    {
        private readonly IDiseaseRepository _repository = repository;
        public async Task<DiseaseDTO> Handle(GetDiseaseByIdQuery request, CancellationToken cancellationToken)
        {
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
