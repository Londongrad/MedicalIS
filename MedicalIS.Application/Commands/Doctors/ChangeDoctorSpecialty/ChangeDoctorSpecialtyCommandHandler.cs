using MediatR;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Enums;

namespace MedicalIS.Application.Commands.Doctors.ChangeDoctorSpecialty
{
    public class ChangeDoctorSpecialtyCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<ChangeDoctorSpecialtyCommand, Unit>
    {
        public async Task<Unit> Handle(ChangeDoctorSpecialtyCommand request, CancellationToken cancellationToken)
        {
            var doctor = await repository.GetByIdAsync(request.Id, cancellationToken);

            if (!Enum.TryParse<Specialty>(request.NewSpecialty, true, out var parsedSpecialty))
                throw new ArgumentException($"Invalid specialty: {request.NewSpecialty}");

            doctor.ChangeSpecialty(parsedSpecialty);
            repository.Update(doctor);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
