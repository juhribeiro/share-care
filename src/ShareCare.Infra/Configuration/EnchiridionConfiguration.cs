using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class EnchiridionConfiguration : IEntityTypeConfiguration<Enchiridion>
    {
        public void Configure(EntityTypeBuilder<Enchiridion> builder)
        {
            builder.Property(x => x.Type)
               .IsRequired();

            builder.Property(x => x.Value)
               .IsRequired();

            builder.Property(x => x.Date)
               .IsRequired();
        }
    }
}
