using MediatR;

namespace MedicalIS.Application.Commands.Doctors.DeleteDoctor
{
    public record DeleteDoctorCommand(Guid Id) : IRequest;
}
