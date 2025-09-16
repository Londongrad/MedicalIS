using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Diseases.GetAllDiseases
{
    public record GetAllDiseasesQuery
        : IRequest<IReadOnlyList<DiseaseDTO>>;
}
