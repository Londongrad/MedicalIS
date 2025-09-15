using MediatR;
using MedicalIS.Application.DTOs;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorById
{
    public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorDTO>;
}
