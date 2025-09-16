using MedicalIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalIS.Infrastructure.Configurations
{
    public class PatientDiseaseConfiguration : IEntityTypeConfiguration<PatientDisease>
    {
        public void Configure(EntityTypeBuilder<PatientDisease> builder)
        {
            builder.HasKey(pd => new { pd.PatientId, pd.DiseaseId });

            builder.HasOne(pd => pd.Patient)
                .WithMany(p => p.Diseases)
                .HasForeignKey(pd => pd.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pd => pd.Disease)
                .WithMany(d => d.PatientDiseases)
                .HasForeignKey(pd => pd.DiseaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(pd => pd.DiagnosedAt)
                .IsRequired();

        }
    }
}
