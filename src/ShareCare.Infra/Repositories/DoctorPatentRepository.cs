using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class DoctorPatentRepository : BaseRepository<DoctorPatient, DoctorPatientModel>,
        IBaseRepository<DoctorPatient, DoctorPatientModel>
    {
        public DoctorPatentRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
