using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Doctors.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler(IDoctorRepository repository, ILogger<GetAllDoctorsQueryHandler> logger)
        : IRequestHandler<GetAllDoctorsQuery, IReadOnlyList<DoctorDTO>>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly ILogger<GetAllDoctorsQueryHandler> _logger = logger;

        public async Task<IReadOnlyList<DoctorDTO>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполняется запрос {QueryName}", 
                nameof(GetAllDoctorsQuery));

            var doctors = await _repository.GetAllAsync(cancellationToken);

            _logger.LogDebug(
                "Запрос {QueryName} успешно выполнен. Получено {Count} докторов.",
                nameof(GetAllDoctorsQuery), doctors.Count);

            return doctors
                .Select(d => new DoctorDTO(
                    d.Id,
                    d.FullName,
                    d.PhoneNumber,
                    d.Specialty.ToString(),
                    d.Patients.Select(p => new PatientDTO(
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
