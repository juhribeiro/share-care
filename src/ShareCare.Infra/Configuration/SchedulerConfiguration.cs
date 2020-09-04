using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class SchedulerConfiguration : IEntityTypeConfiguration<Scheduler>
    {
        public void Configure(EntityTypeBuilder<Scheduler> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired();

            builder.Property(x => x.DateStart)
               .IsRequired();

            builder.Property(x => x.DateEnd)
              .IsRequired();

            builder.HasMany(c => c.Enchiridions)
               .WithOne(e => e.Scheduler)
               .HasForeignKey(x => x.SchedulerId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.AddValuesInMapper();
        }
    }
}
