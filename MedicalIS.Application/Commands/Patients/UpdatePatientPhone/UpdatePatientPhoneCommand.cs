using MediatR;

namespace MedicalIS.Application.Commands.Patients.UpdatePatientPhone
{
    public record UpdatePatientPhoneCommand(Guid Id, string NewPhone)
        : IRequest<Unit>;
}
