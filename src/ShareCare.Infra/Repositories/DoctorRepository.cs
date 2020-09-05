using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor, SimpleDoctorModel>,
        IBaseRepository<Doctor, SimpleDoctorModel>
    {
        public DoctorRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
