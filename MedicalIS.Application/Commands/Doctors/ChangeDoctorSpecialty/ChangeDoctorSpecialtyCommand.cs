using MediatR;

namespace MedicalIS.Application.Commands.Doctors.ChangeDoctorSpecialty
{
    public record ChangeDoctorSpecialtyCommand(
        Guid Id,
        string NewSpecialty
    ) : IRequest<Unit>;
}
