using MediatR;
using MedicalIS.Application.DTOs.Doctors;

namespace MedicalIS.Application.Queries.Doctors.GetAllDoctors
{
    public record GetAllDoctorsQuery() : IRequest<IReadOnlyList<DoctorDTO>>;
}
