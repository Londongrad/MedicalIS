using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Patients.UpdatePatientPhone
{
    public class UpdatePatientPhoneCommandHandler(
        IPatientRepository repository, 
        IUnitOfWork unitOfWork,
        ILogger<UpdatePatientPhoneCommandHandler> logger)
        : IRequestHandler<UpdatePatientPhoneCommand>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<UpdatePatientPhoneCommandHandler> _logger = logger;

        public async Task Handle(UpdatePatientPhoneCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для пациента с Id = {PatientId}", 
                nameof(UpdatePatientPhoneCommand), request.Id);

            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            var oldPhone = patient.PhoneNumber;

            patient.ChangePhone(request.NewPhone);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: у пациента с Id = {PatientId} номер телефона изменён с {OldPhone} на {NewPhone}",
                nameof(UpdatePatientPhoneCommand), request.Id, oldPhone, request.NewPhone);
        }
    }
}
