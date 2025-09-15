namespace MedicalIS.Application.DTOs
{
    public record DoctorDTO(
        Guid Id,
        string FullName,
        string PhoneNumber,
        string Scpecialty
    );
}
