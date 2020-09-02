using ShareCare.Model.DbModels;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShareCare.Model.Interfaces
{
    public interface IBaseRepository<TBaseDbModel, TBaseModel>
        where TBaseDbModel : BaseDbModel
        where TBaseModel : BaseModel
    {
        Task<TBaseDbModel> GetByIdAsync(Guid id);

        Task<TBaseModel> AddAsync(TBaseDbModel entity);

        Task UpdateAsync(TBaseDbModel entity);

        Task DeleteAsync(Guid id);

        Task<TBaseModel> GetModelByIdAsync(Guid id);

        Task<List<TBaseModel>> ListByConditionAsync(Expression<Func<TBaseDbModel, bool>> expression);

        Task<TBaseModel> GetByConditionAsync(Expression<Func<TBaseDbModel, bool>> expression);

        Task<List<TBaseModel>> ToListAsync();
    }
}
