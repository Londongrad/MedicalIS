using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Patients.DeletePatient
{
    public class DeletePatientCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePatientCommand, Unit>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _repository.Remove(patient);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
