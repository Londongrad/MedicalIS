using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using MedicalIS.Application.Queries.Doctors.GetAllDoctors;
using MedicalIS.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorsBySpecialty
{
    public class GetDoctorsBySpecialtyQueryHandler(IDoctorRepository repository, ILogger<GetDoctorsBySpecialtyQueryHandler> logger)
        : IRequestHandler<GetDoctorsBySpecialtyQuery, IReadOnlyList<DoctorDTO>>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly ILogger<GetDoctorsBySpecialtyQueryHandler> _logger = logger;

        public async Task<IReadOnlyList<DoctorDTO>> Handle(GetDoctorsBySpecialtyQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Выполнение запроса {QueryName} с параметром Specialty: {Specialty}",
                nameof(GetDoctorsBySpecialtyQuery), request.Specialty);

            if (!Enum.TryParse<Specialty>(request.Specialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.Specialty}"); // Логируется в слое API

            var doctors = await _repository.GetBySpecialtyAsync(parsedSpecialty, cancellationToken);

            _logger.LogDebug("Запрос {QueryName} выполнен. Получено {Count} докторов со специальностью {Specialty}.",
                nameof(GetDoctorsBySpecialtyQuery), doctors.Count, request.Specialty);

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
