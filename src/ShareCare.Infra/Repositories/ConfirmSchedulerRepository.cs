using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class ConfirmSchedulerRepository : BaseRepository<Scheduler, ConfirmSchedulerModel>,
        IBaseRepository<Scheduler, ConfirmSchedulerModel>
    {
        public ConfirmSchedulerRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
