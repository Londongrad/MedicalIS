namespace MedicalIS.Application.DTOs.Doctors
{
    public record CreateDoctorDTO(
        string FullName,
        string PhoneNumber,
        string Scpecialty
    );
}
