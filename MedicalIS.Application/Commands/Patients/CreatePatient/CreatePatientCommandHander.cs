using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Commands.Patients.CreatePatient
{
    public class CreatePatientCommandHander(IPatientRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Gender>(request.Gender, true, out var parsedGender))
                throw new ArgumentException($"Invalid gender: {request.Gender}");

            var patient = new Patient(Guid.NewGuid(), request.FullName, request.DateOfBirth, request.Phone, parsedGender, request.Address);

            await _repository.AddAsync(patient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return patient.Id;
        }
    }
}
