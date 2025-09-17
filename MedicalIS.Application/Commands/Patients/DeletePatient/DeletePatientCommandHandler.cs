using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Patients.DeletePatient
{
    public class DeletePatientCommandHandler(
        IPatientRepository repository, 
        IUnitOfWork unitOfWork,
        ILogger<DeletePatientCommandHandler> logger) : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<DeletePatientCommandHandler> _logger = logger;

        public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для пациента с Id = {PatientId}", 
                nameof(DeletePatientCommand), request.Id);

            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _repository.Remove(patient);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: пациент с Id = {PatientId} удалён",
                nameof(DeletePatientCommand), request.Id);
        }
    }
}
