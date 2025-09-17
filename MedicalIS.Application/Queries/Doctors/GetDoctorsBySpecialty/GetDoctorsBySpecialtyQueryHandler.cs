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
                doctor.Specialty.ToString(),
                doctor.Patients.Select(p => new PatientDTO(
                    p.Id,
                    p.FullName,
                    p.DateOfBirth,
                    p.PhoneNumber,
                    p.Gender.ToString(),
                    p.Address,
                    p.DoctorId,
                    p.Diseases.Select(pd => new PatientDiseaseDTO(
                        pd.DiseaseId,
                        pd.Disease.Name,
                        pd.Disease.Description,
                        pd.DiagnosedAt
                    )).ToList()
                )).ToList()
            )).ToList();
        }
    }
}
