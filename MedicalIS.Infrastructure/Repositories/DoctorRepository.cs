using MedicalIS.Application.Interfaces;
using MedicalIS.Domain.Entities;
using MedicalIS.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace MedicalIS.Infrastructure.Repositories
{
    public class DoctorRepository(ApplicationDbContext context) : IDoctorRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _context.Doctors
                .Where(d => d.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Doctor>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Doctor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<Doctor>> GetBySpecialtyAsync(Specialty specialty, CancellationToken cancellationToken = default)
        {
            return await _context.Doctors
                .AsNoTracking()
                .Where(d => d.Specialty == specialty)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Doctor doctor, CancellationToken cancellationToken = default)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
