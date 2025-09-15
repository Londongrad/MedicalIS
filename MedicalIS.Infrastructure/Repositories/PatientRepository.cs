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

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var patient = await _context.Patients.FindAsync([id], cancellationToken);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync(cancellationToken);
            }

            //await _context.Patients
            //  .Where(p => p.Id == id)
            //  .ExecuteDeleteAsync(cancellationToken);
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

        public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
