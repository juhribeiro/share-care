using Microsoft.EntityFrameworkCore;

namespace ShareCare.Infra.Context
{
    public class SharedCareContext : DbContext
    {
        public SharedCareContext(DbContextOptions<SharedCareContext> options)
              : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
