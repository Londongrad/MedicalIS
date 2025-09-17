using MediatR;
using MedicalIS.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Doctors.DeleteDoctor
{
    internal class DeleteDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork, ILogger<DeleteDoctorCommandHandler> logger)
        : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<DeleteDoctorCommandHandler> _logger = logger;

        public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} для доктора с Id: {Id}", 
                nameof(DeleteDoctorCommand), request.Id);

            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _repository.Remove(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: доктор с Id = {DoctorId} удалён",
                nameof(DeleteDoctorCommand), doctor.Id);
        }
    }
}
