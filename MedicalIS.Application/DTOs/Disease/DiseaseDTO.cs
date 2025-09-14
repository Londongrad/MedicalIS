namespace MedicalIS.Application.DTOs.Disease
{
    public record DiseaseDTO(
        Guid Id,
        string Name,
        string? Description
    );
}
