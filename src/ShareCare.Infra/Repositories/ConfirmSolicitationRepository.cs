using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class ConfirmSolicitationRepository : BaseRepository<Scheduler, DetailSolicitationModel>,
        IBaseRepository<Scheduler, DetailSolicitationModel>
    {
        public ConfirmSolicitationRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
