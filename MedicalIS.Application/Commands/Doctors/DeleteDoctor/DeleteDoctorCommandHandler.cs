using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Doctors.DeleteDoctor
{
    internal class DeleteDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateDoctorPhone, Unit>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateDoctorPhone request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _repository.Remove(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
