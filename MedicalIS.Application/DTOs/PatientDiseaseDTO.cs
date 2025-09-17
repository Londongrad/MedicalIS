namespace MedicalIS.Application.DTOs
{
    public record PatientDiseaseDTO(
        Guid DiseaseId,
        string Name,
        string? Description,
        DateTime DiagnosedAtUtc
    );
}
