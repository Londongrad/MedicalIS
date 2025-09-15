namespace MedicalIS.Application.DTOs.Doctor
{
    public record CreateDoctorDTO(
        string FullName,
        string PhoneNumber,
        string Scpecialty
    );
}
