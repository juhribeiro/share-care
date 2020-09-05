using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class PatientRepository : BaseRepository<Patient, SimplePatientModel>,
        IBaseRepository<Patient, SimplePatientModel>
    {
        public PatientRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
