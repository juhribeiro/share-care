using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.HasOne(dp => dp.Doctor)
              .WithMany(d => d.DoctorPatients)
              .HasForeignKey(dp => dp.DoctorId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(dp => dp.Patient)
              .WithMany(p => p.DoctorPatients)
              .HasForeignKey(dp => dp.PatientId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(dp => dp.Schedulers)
              .WithOne(p => p.DoctorPatient)
              .HasForeignKey(dp => dp.DoctorPatientId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.AddValuesInMapper();
        }
    }
}
