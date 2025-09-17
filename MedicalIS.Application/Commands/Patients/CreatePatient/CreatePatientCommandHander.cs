using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace MedicalIS.Application.Commands.Patients.CreatePatient
{
    public class CreatePatientCommandHander(
        IPatientRepository repository, 
        IUnitOfWork unitOfWork,
        ILogger<CreatePatientCommandHander> logger)
        : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<CreatePatientCommandHander> _logger = logger;

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Выполняется команда {CommandName}: создание пациента {FullName}, дата рождения {DateOfBirth}, пол {Gender}",
                nameof(CreatePatientCommand), request.FullName, request.DateOfBirth, request.Gender);

            if (!Enum.TryParse<Gender>(request.Gender, true, out var parsedGender))
                throw new ArgumentException($"Invalid gender: {request.Gender}");

            var patient = new Patient(Guid.NewGuid(), request.FullName, request.DateOfBirth, request.Phone, parsedGender, request.Address);

            await _repository.AddAsync(patient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation(
                "Команда {CommandName} успешно выполнена: создан пациент с Id = {PatientId}, имя = {FullName}",
                nameof(CreatePatientCommand), patient.Id, patient.FullName);

            return patient.Id;
        }
    }
}
