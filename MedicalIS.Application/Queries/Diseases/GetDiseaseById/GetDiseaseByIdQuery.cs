using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Diseases.GetDiseaseById
{
    public record GetDiseaseByIdQuery(Guid Id) : IRequest<DiseaseDTO>;
}
