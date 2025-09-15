using MediatR;

namespace MedicalIS.Application.Commands.Patients.CreatePatient
{
    public record CreatePatientCommand(
        string FullName,
        DateTime DateOfBirth,
        string Phone,
        string Gender,
        string Address
    ) : IRequest<Guid>;
}
