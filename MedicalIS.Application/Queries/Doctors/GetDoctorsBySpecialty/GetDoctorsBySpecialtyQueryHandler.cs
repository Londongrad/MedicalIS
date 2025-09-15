using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty
{
    public class GetDoctorsBySpecialtyQueryHandler(IDoctorRepository repository)
        : IRequestHandler<GetDoctorsBySpecialtyQuery, IReadOnlyList<DoctorDTO>>
    {
        private readonly IDoctorRepository _repository = repository;
        public async Task<IReadOnlyList<DoctorDTO>> Handle(GetDoctorsBySpecialtyQuery request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Specialty>(request.Specialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.Specialty}");

            var doctors = await _repository.GetBySpecialtyAsync(parsedSpecialty, cancellationToken);

            return doctors.Select(doctor => new DoctorDTO(
                doctor.Id,
                doctor.FullName,
                doctor.PhoneNumber,
                doctor.Specialty.ToString()
            )).ToList();
        }
    }
}
