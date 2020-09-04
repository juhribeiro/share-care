using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Configuration
{
    public static partial class ValueGenerateMapping
    {
        public static EntityTypeBuilder<TBaseDbModel> AddValuesInMapper<TBaseDbModel>(
        this EntityTypeBuilder<TBaseDbModel> builder)
        where TBaseDbModel : BaseDbModel
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .ValueGeneratedOnAdd();

            return builder;
        }
    }
}
