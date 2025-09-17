using MedicalIS.Application.Exceptions;
using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : IDoctorRepository
    {
        private readonly ApplicationDbContext _context = context;

        /// <inheritdoc />
        public async Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            await _context.Doctors.AddAsync(doctor, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .Include(d => d.Patients)
                    .ThenInclude(p => p.Diseases)
                        .ThenInclude(pd => pd.Disease)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Doctor> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .Include(d => d.Patients)
                    .ThenInclude(p => p.Diseases)
                        .ThenInclude(pd => pd.Disease)
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken)
                ?? throw new NotFoundException(nameof(Doctor), id);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(Specialty specialty, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .Where(d => d.Specialty == specialty)
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        /// <inheritdoc />
        public void Remove(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}
