using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Patients.AssignDoctor
{
    public class AssignDoctorCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<AssignDoctorCommand, Unit>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(AssignDoctorCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.PatientId, cancellationToken);

            patient.AssignDoctor(request.DoctorId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
