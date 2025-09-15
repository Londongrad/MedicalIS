using MediatR;

namespace MedicalIS.Application.Commands.Doctors.DeleteDoctor
{
    public record UpdateDoctorPhone(Guid Id) : IRequest<Unit>;
}
