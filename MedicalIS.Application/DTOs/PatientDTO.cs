namespace MedicalIS.Application.DTOs
{
    public record PatientDTO(
        Guid Id,
        string FullName,
        DateOnly DateOfBirth,
        string Phone,
        string Gender,
        string Address,
        Guid? DoctorId,
        IReadOnlyList<PatientDiseaseDTO> Diseases
    );
}
