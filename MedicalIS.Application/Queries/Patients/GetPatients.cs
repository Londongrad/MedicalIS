using MediatR;
using MedicalIS.Application.DTOs.Patients;

namespace MedicalIS.Application.Queries.Patients
{
    public record GetPatientsQuery() : IRequest<List<PatientDto>>;
}
