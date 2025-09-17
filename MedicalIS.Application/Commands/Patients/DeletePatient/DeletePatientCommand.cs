using MediatR;

namespace MedicalIS.Application.Commands.Patients.DeletePatient
{
    public record DeletePatientCommand(Guid Id) : IRequest;
}
