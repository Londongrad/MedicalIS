using MediatR;
using MedicalIS.Application.DTOs.Patient;

namespace MedicalIS.Application.Queries.Patients
{
    public record GetPatientsQuery() : IRequest<List<PatientDto>>;
}
