using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;
using ShareCare.Model.Enums;

namespace ShareCare.Infra.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.Name)
             .IsRequired();

            builder.HasDiscriminator(b => b.Type)
                .HasValue<Doctor>(PersonType.Doctor)
                .HasValue<Patient>(PersonType.Patient);

            builder.HasMany(c => c.Contacts)
                .WithOne(e => e.Person)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.AddValuesInMapper();
        }
    }
}
