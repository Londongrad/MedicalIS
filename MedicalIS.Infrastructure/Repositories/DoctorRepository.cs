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
            await _context.Doctors.AddAsync(doctor, cancellationToken);
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

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }

        public void Remove(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}
