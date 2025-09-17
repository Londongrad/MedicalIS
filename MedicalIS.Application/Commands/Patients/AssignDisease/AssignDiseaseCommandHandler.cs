using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Patients.AssignDisease
{
    public class AssignDiseaseCommandHandler(
        IPatientRepository patientRepository, 
        IDiseaseRepository diseaseRepository, 
        IUnitOfWork unitOfWork,
        ILogger<AssignDiseaseCommandHandler> logger)
        : IRequestHandler<AssignDiseaseCommand>
    {
        private readonly IPatientRepository _patientRepository = patientRepository;
        private readonly IDiseaseRepository _diseaseRepository = diseaseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<AssignDiseaseCommandHandler> _logger = logger;

        public async Task Handle(AssignDiseaseCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для пациента с Id = {PatientId}", 
                nameof(AssignDiseaseCommand), request.PatientId);

            var patient = await _patientRepository.GetByIdAsync(request.PatientId, cancellationToken);
            var disease = await _diseaseRepository.GetByIdAsync(request.DiseaseId, cancellationToken);

            patient.AddDisease(disease, request.DiagnosedAt);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: пациент с Id = {PatientId} получил диагноз {DiseaseName} (Id = {DiseaseId}, дата: {DiagnosedAt})",
                nameof(AssignDiseaseCommand), request.PatientId, disease.Name, disease.Id, request.DiagnosedAt);
        }
    }
}
