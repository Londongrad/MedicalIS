using MediatR;

namespace MedicalIS.Application.Commands.Patients.AssignDisease
{
    public record AssignDiseaseCommand(Guid PatientId, Guid DiseaseId, DateTime DiagnosedAt) : IRequest;
}
