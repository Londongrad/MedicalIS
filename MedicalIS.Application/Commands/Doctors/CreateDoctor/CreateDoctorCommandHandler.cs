using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Doctors.CreateDoctor
{
    public class CreateDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork, ILogger<CreateDoctorCommandHandler> logger)
        : IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreateDoctorCommandHandler> _logger = logger;

        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполнение команды {CommandName} с параметрами: имя {FullName}, телефон {PhoneNumber}, специальность {Specialty}",
                nameof(CreateDoctorCommand), request.FullName, request.PhoneNumber, request.Specialty);

            if (!Enum.TryParse<Specialty>(request.Specialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.Specialty}");

            var doctor = new Doctor(Guid.NewGuid(), request.FullName, request.PhoneNumber, parsedSpecialty);

            await _repository.AddAsync(doctor, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: создан доктор с Id = {DoctorId}, специальность = {Specialty}",
                nameof(CreateDoctorCommand), doctor.Id, doctor.Specialty);

            return doctor.Id;
        }
    }
}
