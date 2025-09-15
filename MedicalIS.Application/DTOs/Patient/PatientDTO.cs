namespace MedicalIS.Application.DTOs.Patient
{
    public record PatientDto(
        Guid Id,
        string FullName,
        DateTime DateOfBirth,
        string Phone,
        string Gender,
        string Address,
        Guid DoctorId
    );
}
