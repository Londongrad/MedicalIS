using MedicalIS.Application.Interfaces;
using MedicalIS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalIS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
