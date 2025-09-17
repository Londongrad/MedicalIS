using MediatR;

namespace MedicalIS.Application.Commands.Patients.AssignDoctor
{
    public record AssignDoctorCommand(Guid PatientId, Guid DoctorId) : IRequest;
}
