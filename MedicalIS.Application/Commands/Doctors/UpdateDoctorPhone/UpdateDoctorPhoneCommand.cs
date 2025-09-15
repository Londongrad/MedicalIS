using MediatR;

namespace MedicalIS.Application.Commands.Doctors.UpdateDoctorPhone
{
    public record UpdateDoctorPhoneCommand(
        Guid Id,
        string NewPhoneNumber
    ) : IRequest<Unit>;
}
