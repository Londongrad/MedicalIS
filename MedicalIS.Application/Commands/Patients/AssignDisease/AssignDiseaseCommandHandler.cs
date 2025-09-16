using MediatR;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Commands.Patients.AssignDisease
{
    public class AssignDiseaseCommandHandler(IPatientRepository patientRepository, IDiseaseRepository diseaseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<AssignDiseaseCommand>
    {
        private readonly IPatientRepository _patientRepository = patientRepository;
        private readonly IDiseaseRepository _diseaseRepository = diseaseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AssignDiseaseCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.PatientId, cancellationToken);
            var disease = await _diseaseRepository.GetByIdAsync(request.DiseaseId, cancellationToken);

            patient.AddDisease(disease, request.DiagnosedAt);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
