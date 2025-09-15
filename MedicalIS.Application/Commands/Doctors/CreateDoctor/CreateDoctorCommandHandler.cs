using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Commands.Doctors.CreateDoctor
{
    public class CreateDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateDoctorCommand, Guid>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Specialty>(request.Specialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.Specialty}");

            var doctor = new Doctor(Guid.NewGuid(), request.FullName, request.PhoneNumber, parsedSpecialty);

            await _repository.AddAsync(doctor, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return doctor.Id;
        }
    }
}
