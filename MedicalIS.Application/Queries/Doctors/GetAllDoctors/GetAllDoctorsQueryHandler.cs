using MediatR;
using MedicalIS.Application.DTOs.Doctor;
using MedicalIS.Application.Interfaces;

namespace MedicalIS.Application.Queries.Doctors.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler(IDoctorRepository repository)
        : IRequestHandler<GetAllDoctorsQuery, IReadOnlyList<DoctorDTO>>
    {
        private readonly IDoctorRepository _repository = repository;

        public async Task<IReadOnlyList<DoctorDTO>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _repository.GetAllAsync(cancellationToken);

            return doctors
                .Select(d => new DoctorDTO(d.Id, d.FullName, d.PhoneNumber, d.Specialty.ToString()))
                .ToList();
        }
    }
}
