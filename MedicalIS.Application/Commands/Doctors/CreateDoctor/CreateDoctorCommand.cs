using MediatR;

namespace MedicalIS.Application.Commands.Doctors.CreateDoctor
{
    public record CreateDoctorCommand(
        string FullName,
        string PhoneNumber,
        string Specialty
    ) : IRequest<Guid>;
}
