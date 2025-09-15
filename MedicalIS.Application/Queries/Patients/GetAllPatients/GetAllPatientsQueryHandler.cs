using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Patients.GetAllPatients
{
    public class GetAllPatientsQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetAllPatientsQuery, IReadOnlyList<PatientDTO>>
    {
        private readonly IPatientRepository _repository = patientRepository;

        public async Task<IReadOnlyList<PatientDTO>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _repository.GetAllAsync(cancellationToken);

            return patients
                .Select(p => new PatientDTO(p.Id, p.FullName, p.DateOfBirth, p.PhoneNumber, p.Gender.ToString(), p.Address))
                .ToList();
        }
    }
}
