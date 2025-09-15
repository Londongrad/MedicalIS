namespace MedicalIS.Application.DTOs
{
    public record DiseaseDTO(
        Guid Id,
        string Name,
        string? Description
    );
}
