using AutoMapper;
using ShareCare.Model.DbModels;
using ShareCare.Model.Models;

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

            CreateMap<SimplePersonModel, Person>()
                .Include<SimpleDoctorModel, Doctor>()
                .Include<SimplePatientModel, Patient>();

            CreateMap<SimpleDoctorModel, Doctor>()
                .ForMember(x => x.Specialties, o => o.MapFrom(x => x.Specialties))
                .ReverseMap();

            CreateMap<SimplePatientModel, Patient>()
            .ReverseMap();

            CreateMap<DiaryModel, Diary>()
               .ReverseMap();

            CreateMap<SchedulerModel, Scheduler>()
                .ForMember(x => x.Specialty, o => o.MapFrom(x => x.Specialty))
              .ReverseMap();

            CreateMap<EnchiridionModel, Enchiridion>()
             .ForPath(x => x.Scheduler.Specialty, o => o.MapFrom(x => x.Specialty))
             .ReverseMap();
        }
    }
}
