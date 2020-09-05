using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class SchedulerRepository : BaseRepository<Scheduler, SchedulerModel>,
        IBaseRepository<Scheduler, SchedulerModel>
    {
        public SchedulerRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
