using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Patients.GetPatientById
{
    public record GetPatientByIdQuery(Guid Id) : IRequest<PatientDTO>;
}
