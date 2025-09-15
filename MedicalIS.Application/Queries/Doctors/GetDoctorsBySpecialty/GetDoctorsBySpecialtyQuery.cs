using MediatR;
using MedicalIS.Application.DTOs.Doctor;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty
{
    public record GetDoctorsBySpecialtyQuery(string Specialty) : IRequest<IReadOnlyList<DoctorDTO>>;
}
