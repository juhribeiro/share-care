using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShareCare.Infra.Context;
using ShareCare.Model.DbModels;
using ShareCare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShareCare.Infra.Repositories
{
    public abstract class BaseRepository<TBaseDbModel, TBaseModel>
        where TBaseDbModel : BaseDbModel
        where TBaseModel : BaseModel
    {
        private readonly ShareCareContext context;
        private readonly IMapper mapper;
        private readonly DbSet<TBaseDbModel> setDb;

        protected BaseRepository(ShareCareContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            setDb = context.Set<TBaseDbModel>();
        }

        public async Task<TBaseDbModel> GetByIdAsync(Guid id)
        {
            return await setDb.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TBaseModel> AddAsync(TBaseDbModel entity)
        {
            await setDb.AddAsync(entity);
            await context.SaveChangesAsync();
            return mapper.Map<TBaseModel>(entity);
        }

        public async Task UpdateAsync(TBaseDbModel entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            TBaseDbModel entity = await setDb.SingleOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                setDb.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public Task<TBaseModel> GetModelByIdAsync(Guid id)
        {
            return setDb.AsNoTracking().ProjectTo<TBaseModel>(mapper.ConfigurationProvider).SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<TBaseModel>> ListByConditionAsync(Expression<Func<TBaseDbModel, bool>> expression)
        {
            return await setDb.Where(expression).ProjectTo<TBaseModel>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<TBaseModel> GetByConditionAsync(Expression<Func<TBaseDbModel, bool>> expression)
        {
            TBaseDbModel entity = await setDb.FirstOrDefaultAsync(expression);
            return mapper.Map<TBaseModel>(entity);
        }

        public async Task<List<TBaseModel>> ToListAsync()
        {
            return await setDb.ProjectTo<TBaseModel>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
