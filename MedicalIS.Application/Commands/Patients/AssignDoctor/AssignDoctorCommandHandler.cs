using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Patients.AssignDoctor
{
    public class AssignDoctorCommandHandler(
        IPatientRepository repository, 
        IUnitOfWork unitOfWork,
        ILogger<AssignDoctorCommandHandler> logger)
        : IRequestHandler<AssignDoctorCommand>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<AssignDoctorCommandHandler> _logger = logger;

        public async Task Handle(AssignDoctorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для пациента с Id = {PatientId}", 
                nameof(AssignDoctorCommand), request.PatientId);

            var patient = await _repository.GetByIdAsync(request.PatientId, cancellationToken);

            patient.AssignDoctor(request.DoctorId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена. Пациенту с Id = {PatientId} был назначен доктор с Id = {DoctorId}",
                nameof(AssignDoctorCommand), request.PatientId, request.DoctorId);
        }
    }
}
