using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Patients
{
    public record GetPatientsQuery() : IRequest<List<PatientDTO>>;
}
