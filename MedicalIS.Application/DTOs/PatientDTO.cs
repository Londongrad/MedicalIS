namespace MedicalIS.Application.DTOs
{
    public record PatientDTO(
        Guid Id,
        string FullName,
        DateTime DateOfBirth,
        string Phone,
        string Gender,
        string Address,
        Guid DoctorId
    );
}
