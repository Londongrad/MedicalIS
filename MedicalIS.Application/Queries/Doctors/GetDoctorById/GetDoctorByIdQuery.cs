using MediatR;
using MedicalIS.Application.DTOs.Doctors;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorById
{
    public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorDTO?>;
}
