using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Patients.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

    }
}
