using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Patients.GetPatientById
{
    public class GetPatientByIdQueryHandler(IPatientRepository repository)
        : IRequestHandler<GetPatientByIdQuery, PatientDTO>
    {
        private readonly IPatientRepository _repository = repository;

        public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return new PatientDTO(
                patient.Id,
                patient.FullName,
                patient.DateOfBirth,
                patient.PhoneNumber,
                patient.Gender.ToString(),
                patient.Address
            );
        }
    }
}
