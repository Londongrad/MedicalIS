using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Doctors.UpdateDoctorPhone
{
    public class UpdateDoctorPhoneCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork, ILogger<UpdateDoctorPhoneCommandHandler> logger)
        : IRequestHandler<UpdateDoctorPhoneCommand>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<UpdateDoctorPhoneCommandHandler> _logger = logger;

        public async Task Handle(UpdateDoctorPhoneCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для доктора с Id: {Id}",
                nameof(UpdateDoctorPhoneCommand), request.Id);

            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            var oldPhone = doctor.PhoneNumber;

            doctor.ChangePhone(request.NewPhoneNumber);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена. Телефон врача изменён с {OldPhone} на {NewPhone}", 
                nameof(UpdateDoctorPhoneCommand), oldPhone, request.NewPhoneNumber);
        }
    }
}
