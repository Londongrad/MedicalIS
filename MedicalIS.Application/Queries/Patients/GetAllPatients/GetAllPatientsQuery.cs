using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Patients.GetAllPatients
{
    public record GetAllPatientsQuery() : IRequest<IReadOnlyList<PatientDTO>>;
}
