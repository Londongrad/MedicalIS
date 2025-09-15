using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Patients.GetAllPatients
{
    public record GetPatientsQuery() : IRequest<IReadOnlyList<PatientDTO>>;
}
