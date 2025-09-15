using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Doctors.UpdateDoctorPhone
{
    public class UpdateDoctorPhoneCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateDoctorPhoneCommand, Unit>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateDoctorPhoneCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            doctor.ChangePhone(request.NewPhoneNumber);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
