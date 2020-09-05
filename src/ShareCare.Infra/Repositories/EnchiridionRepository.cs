using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class EnchiridionRepository : BaseRepository<Enchiridion, EnchiridionModel>,
        IBaseRepository<Enchiridion, EnchiridionModel>
    {
        public EnchiridionRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
