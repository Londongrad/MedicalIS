using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorById
{
    public class GetDoctorByIdQueryHandler(IDoctorRepository repository) : IRequestHandler<GetDoctorByIdQuery, DoctorDTO?>
    {
        private readonly IDoctorRepository _repository = repository;

        public async Task<DoctorDTO?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Doctor), request.Id);

            return new DoctorDTO(
                doctor.Id,
                doctor.FullName,
                doctor.PhoneNumber,
                doctor.Specialty.ToString()
            );
        }
    }
}
