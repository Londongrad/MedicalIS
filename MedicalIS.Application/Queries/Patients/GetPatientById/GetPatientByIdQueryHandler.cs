using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Queries.Patients.GetPatientById
{
    public class GetPatientByIdQueryHandler(IPatientRepository repository, ILogger<GetPatientByIdQueryHandler> logger)
        : IRequestHandler<GetPatientByIdQuery, PatientDTO>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly ILogger<GetPatientByIdQueryHandler> _logger = logger;

        public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение запроса {QueryName} для пациента с Id = {Id}", 
                nameof(GetPatientByIdQuery), request.Id);

            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return new PatientDTO(
                patient.Id,
                patient.FullName,
                patient.DateOfBirth,
                patient.PhoneNumber,
                patient.Gender.ToString(),
                patient.Address,
                patient.DoctorId,
                patient.Diseases.Select(pd => new PatientDiseaseDTO(
                        pd.DiseaseId,
                        pd.Disease.Name,
                        pd.Disease.Description,
                        pd.DiagnosedAt)
                    ).ToList()
            );
        }
    }
}
