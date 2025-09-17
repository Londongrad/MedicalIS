using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Patients.GetAllPatients
{
    public class GetAllPatientsQueryHandler(IPatientRepository patientRepository, ILogger<GetAllPatientsQueryHandler> logger)
        : IRequestHandler<GetAllPatientsQuery, IReadOnlyList<PatientDTO>>
    {
        private readonly IPatientRepository _repository = patientRepository;
        private readonly ILogger<GetAllPatientsQueryHandler> _logger = logger;

        public async Task<IReadOnlyList<PatientDTO>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполняется запрос {QueryName}", 
                nameof(GetAllPatientsQuery));

            var patients = await _repository.GetAllAsync(cancellationToken);

            _logger.LogDebug(
                "Запрос {QueryName} успешно выполнен. Получено {Count} пациентов.",
                nameof(GetAllPatientsQuery), patients.Count);

            return patients
                .Select(p => new PatientDTO(
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
                        pd.DiagnosedAt)
                    ).ToList()
                ))
                .ToList();
        }
    }
}
