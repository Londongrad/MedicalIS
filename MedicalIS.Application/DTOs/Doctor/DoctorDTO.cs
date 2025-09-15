namespace MedicalIS.Application.DTOs.Doctor
{
    public record DoctorDTO(
        Guid Id,
        string FullName,
        string PhoneNumber,
        string Scpecialty
    );
}
