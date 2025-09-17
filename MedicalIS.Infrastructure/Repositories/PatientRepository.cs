using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class PatientRepository(ApplicationDbContext context) : IPatientRepository
    {
        private readonly ApplicationDbContext _context = context;

        /// <inheritdoc />
        public async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
        {
            await _context.Patients.AddAsync(patient, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<Patient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Patients
                .Include(p => p.Diseases)
                .ThenInclude(pt => pt.Disease)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Patients
                .Include(p => p.Diseases)
                .ThenInclude(pt => pt.Disease)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Patient), id);
        }

        /// <inheritdoc />
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        /// <inheritdoc />
        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}
