using MediatR;

namespace MedicalIS.Application.Commands.Patients.CreatePatient
{
    public record CreatePatientCommand(
        string FullName,
        DateOnly DateOfBirth,
        string Phone,
        string Gender,
        string Address
    ) : IRequest<Guid>;
}
