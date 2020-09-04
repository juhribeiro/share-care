using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public class DiaryConfiguration : IEntityTypeConfiguration<Diary>
    {
        public void Configure(EntityTypeBuilder<Diary> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired();

            builder.AddValuesInMapper();
        }
    }
}
