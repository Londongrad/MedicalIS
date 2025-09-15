using MediatR;
using MedicalIS.Application.DTOs.Doctors;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty
{
    public record GetDoctorsBySpecialtyQuery(string Specialty) : IRequest<IReadOnlyList<DoctorDTO>>;
}
