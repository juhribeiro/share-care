using AutoMapper;
using ShareCare.Model.DbModels;
using ShareCare.Model.Hash;
using ShareCare.Model.Models;
using System.Linq;

namespace ShareCare.Model.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Specialty, string>()
             .ConvertUsing(src => src.Value);

            CreateMap<string, Specialty>()
               .ConstructUsing(str => new Specialty { Value = str });

            CreateMap<BaseModel, BaseDbModel>()
                .ReverseMap();

            CreateMap<ContactModel, Contact>()
                .ReverseMap();

            CreateMap<SimplePersonModel, Person>()
                 .ForMember(x => x.Password, o => o.MapFrom(x => Cryptography.GetHashString(x.Password)))
                .Include<SimpleDoctorModel, Doctor>()
                .Include<SimplePatientModel, Patient>()
                .ReverseMap();

            CreateMap<SimpleDoctorModel, Doctor>()
                .ForMember(x => x.Specialties, o => o.MapFrom(x => x.Specialties))
                .ReverseMap();

            CreateMap<SimplePatientModel, Patient>();


            CreateMap<Patient, SimplePatientModel>()
               .ForMember(x => x.Specialties, o => o.MapFrom(x => x.DoctorPatients.SelectMany(s => s.Schedulers).Select(x => x.Specialty).ToList()));

            CreateMap<SimplePersonModel, LoginModel>()
                .ForMember(x => x.Email, o => o.MapFrom(x => x.Contacts.First().Value));

            CreateMap<DiaryModel, Diary>()
               .ReverseMap();

            CreateMap<Scheduler, ConfirmSchedulerModel>()
                 .ForMember(x => x.DoctorName, o => o.MapFrom(x => x.DoctorPatient.Doctor.Name));

            CreateMap<Scheduler, ConfirmSolicitationModel>()
                .ForMember(x => x.PatientName, o => o.MapFrom(x => x.DoctorPatient.Patient.Name));

            CreateMap<DoctorPatientModel, DoctorPatient>()
               .ReverseMap();

            CreateMap<Scheduler, EnchiridionDoctorModel>()
                  .ForMember(x => x.Name, o => o.MapFrom(x => x.DoctorPatient.Doctor.Name))
                  .ForMember(x => x.CRM, o => o.MapFrom(x => x.DoctorPatient.Doctor.CRM))
                  .ForMember(x => x.DataStart, o => o.MapFrom(x => x.DateStart))
                  .ForMember(x => x.Specialty, o => o.MapFrom(x => x.Specialty))
                  .ForMember(x => x.Enchiridion, o => o.MapFrom(x => x.Enchiridions));

            CreateMap<SchedulerModel, Scheduler>()
                .ForPath(x => x.DoctorPatient.DoctorId, o => o.MapFrom(x => x.DoctorPatient.DoctorId))
                .ForPath(x => x.DoctorPatient.PatientId, o => o.MapFrom(x => x.DoctorPatient.PatientId))
                .ForMember(x => x.Specialty, o => o.MapFrom(x => x.Specialty))
              .ReverseMap();

            CreateMap<EnchiridionModel, Enchiridion>()
             .ForPath(x => x.Scheduler.Specialty, o => o.MapFrom(x => x.Specialty))
             .ReverseMap();
        }
    }
}
