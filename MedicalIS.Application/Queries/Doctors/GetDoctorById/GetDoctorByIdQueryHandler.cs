using MediatR;
using MedicalIS.Application.DTOs;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Doctors.GetDoctorById
{
    public class GetDoctorByIdQueryHandler(IDoctorRepository repository) 
        : IRequestHandler<GetDoctorByIdQuery, DoctorDTO>
    {
        private readonly IDoctorRepository _repository = repository;

        public async Task<DoctorDTO> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return new DoctorDTO(
                doctor.Id,
                doctor.FullName,
                doctor.PhoneNumber,
                doctor.Specialty.ToString(),
                doctor.Patients.Select(p => new PatientDTO(
                        p.Id,
                        p.FullName,
                        p.DateOfBirth,
                        p.PhoneNumber,
                        p.Gender.ToString(),
                        p.Address,
                        p.DoctorId,
                        p.Diseases.Select(pd => new PatientDiseaseDTO(
                            pd.DiseaseId,
                            pd.Disease.Name,
                            pd.Disease.Description,
                            pd.DiagnosedAt
                        )).ToList()
                    )).ToList()
            );
        }
    }
}
