namespace MedicalIS.Application.DTOs.Doctors
{
    public record DoctorDTO(
        Guid Id,
        string FullName,
        string PhoneNumber,
        string Scpecialty
    );
}
