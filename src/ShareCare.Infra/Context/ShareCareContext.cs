using Microsoft.EntityFrameworkCore;
using ShareCare.Infra.Configuration;
using ShareCare.Model.DbModels;

namespace ShareCare.Infra.Context
{
    public class ShareCareContext : DbContext
    {
        public ShareCareContext(DbContextOptions<ShareCareContext> options)
              : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<HealthPlan> HealthPlans { get; set; }

        public DbSet<DoctorPatient> DoctorPatient { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Diary> Diaries { get; set; }

        public DbSet<Scheduler> Schedulers { get; set; }

        public DbSet<Enchiridion> Enchiridions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new DiaryConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorPatientConfiguration());
            modelBuilder.ApplyConfiguration(new HealthPlanConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new SchedulerConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new EnchiridionConfiguration());
        }
    }
}
