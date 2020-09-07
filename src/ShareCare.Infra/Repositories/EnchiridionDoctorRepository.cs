using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class EnchiridionDoctorRepository : BaseRepository<Scheduler, EnchiridionDoctorModel>,
        IBaseRepository<Scheduler, EnchiridionDoctorModel>
    {
        public EnchiridionDoctorRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
