using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class DiaryRepository : BaseRepository<Diary, DiaryModel>,
        IBaseRepository<Diary, DiaryModel>
    {
        public DiaryRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
