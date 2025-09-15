using MediatR;
using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Commands.Patients.UpdatePatientPhone
{
    public class UpdatePatientPhoneCommandHandler(IPatientRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdatePatientPhoneCommand, Unit>
    {
        private readonly IPatientRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdatePatientPhoneCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Patient), request.Id);

            patient.ChangePhone(request.NewPhone);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
