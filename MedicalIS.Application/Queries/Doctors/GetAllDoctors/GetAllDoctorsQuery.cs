using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Doctors.GetAllDoctors
{
    public record GetAllDoctorsQuery() : IRequest<IReadOnlyList<DoctorDTO>>;
}
