using MediatR;
using MedicalIS.Application.DTOs.Doctor;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorById
{
    public record GetDoctorByIdQuery(Guid Id) : IRequest<DoctorDTO?>;
}
