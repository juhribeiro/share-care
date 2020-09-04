using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(c => c.HealthPlan)
                .WithOne(e => e.Patient)
                .HasForeignKey<HealthPlan>(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Diaries)
               .WithOne(e => e.Patient)
               .HasForeignKey(x => x.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
