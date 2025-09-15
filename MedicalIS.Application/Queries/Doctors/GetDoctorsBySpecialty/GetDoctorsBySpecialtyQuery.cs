using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty
{
    public record GetDoctorsBySpecialtyQuery(string Specialty) : IRequest<IReadOnlyList<DoctorDTO>>;
}
