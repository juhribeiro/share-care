using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired();

            builder.AddValuesInMapper();
        }
    }
}
