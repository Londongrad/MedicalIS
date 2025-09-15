using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Patients.UpdatePatientPhone
{
    public class UpdatePatientPhoneCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdatePatientPhoneCommand, Unit>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdatePatientPhoneCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            patient.ChangePhone(request.NewPhone);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
