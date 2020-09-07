using AutoMapper;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Interfaces;
using ShareCare.Model.Models;

namespace ShareCare.Infra.Repositories
{
    public class PersonRepository : BaseRepository<Person, SimplePersonModel>,
        IBaseRepository<Person, SimplePersonModel>
    {
        public PersonRepository(ShareCareContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
