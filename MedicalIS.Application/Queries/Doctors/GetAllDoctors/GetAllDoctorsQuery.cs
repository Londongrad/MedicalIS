using MediatR;
using MedicalIS.Application.DTOs.Doctor;

namespace MedicalIS.Application.Queries.Doctors.GetAllDoctors
{
    public record GetAllDoctorsQuery() : IRequest<IReadOnlyList<DoctorDTO>>;
}
