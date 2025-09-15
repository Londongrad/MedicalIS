using MediatR;
using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;

namespace MedicalIS.Application.Commands.Doctors.DeleteDoctor
{
    internal class DeleteDoctorCommandHandler(IDoctorRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateDoctorPhone, Unit>
    {
        private readonly IDoctorRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateDoctorPhone request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Doctor), request.Id);

            _repository.Remove(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
