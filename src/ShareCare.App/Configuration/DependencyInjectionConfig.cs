using Microsoft.Extensions.DependencyInjection;
using ShareCare.Infra.Context;
using ShareCare.Infra.Repositories;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;
using ShareCare.Service.Services;

namespace ShareCare.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ShareCareContext>();

            services.AddScoped<IBaseRepository<Diary, DiaryModel>, DiaryRepository>();
            services.AddScoped<IBaseRepository<Doctor, SimpleDoctorModel>, DoctorRepository>();
            services.AddScoped<IBaseRepository<Enchiridion, EnchiridionModel>, EnchiridionRepository>();
            services.AddScoped<IBaseRepository<Patient, SimplePatientModel>, PatientRepository>();
            services.AddScoped<IBaseRepository<Scheduler, SchedulerModel>, SchedulerRepository>();
            services.AddScoped<IBaseRepository<Person, SimplePersonModel>, PersonRepository>();
            services.AddScoped<IBaseRepository<DoctorPatient, DoctorPatientModel>, DoctorPatentRepository>();
            services.AddScoped<IBaseRepository<Scheduler, ConfirmSchedulerModel>, ConfirmSchedulerRepository>();
            services.AddScoped<IBaseRepository<Scheduler, ConfirmSolicitationModel>, ConfirmSolicitationRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IMedicalGuideService, MedicalGuideService>();
            services.AddScoped<IPatientGuideService, PatientGuideService>();
            services.AddScoped<ISchedulerService, SchedulerService>();

            return services;
        }
    }
}
