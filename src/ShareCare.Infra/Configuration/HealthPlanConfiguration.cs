using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class HealthPlanConfiguration : IEntityTypeConfiguration<HealthPlan>
    {
        public void Configure(EntityTypeBuilder<HealthPlan> builder)
        {
            builder.Property(x => x.Code)
                .IsRequired();

            builder.AddValuesInMapper();
        }
    }
}
