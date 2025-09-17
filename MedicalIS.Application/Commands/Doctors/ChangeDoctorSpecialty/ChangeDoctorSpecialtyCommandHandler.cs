using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Doctors.ChangeDoctorSpecialty
{
    public class ChangeDoctorSpecialtyCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork, ILogger<ChangeDoctorSpecialtyCommandHandler> logger)
        : IRequestHandler<ChangeDoctorSpecialtyCommand>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<ChangeDoctorSpecialtyCommandHandler> _logger = logger;

        public async Task Handle(ChangeDoctorSpecialtyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для доктора с Id = {DoctorId}",
                nameof(ChangeDoctorSpecialtyCommand), request.Id);

            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (!Enum.TryParse<Specialty>(request.NewSpecialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.NewSpecialty}");

            var oldSpecialty = doctor.Specialty; // Фиксирую старую специальность для лога

            doctor.ChangeSpecialty(parsedSpecialty);
            _repository.Update(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: у доктора с Id = {DoctorId} специальность изменена с {OldSpecialty} на {NewSpecialty}",
                nameof(ChangeDoctorSpecialtyCommand), doctor.Id, oldSpecialty, parsedSpecialty);
        }
    }
}
