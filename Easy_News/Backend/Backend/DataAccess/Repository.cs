using AutoMapper;
using Backend.Logger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public class Repository<DBEntity, ModelEntity> : IRepository<DBEntity, ModelEntity>
        where DBEntity : class, new()
        where ModelEntity : class, Dbo.IObjectWithId, new()
    {

        private DbSet<DBEntity> _set;
        protected EFModels.earlynews_testContext _context;
        protected readonly IMapper _mapper;
        public bool Log = true;

        public Repository(EFModels.earlynews_testContext ctx, IMapper mapper)
        {
            _mapper = mapper;
            _context = ctx;
            _set = _context.Set<DBEntity>();
        }

        public virtual async Task<bool> Delete(long idEntity)
        {
            DBEntity dBEntity = _set.Find(idEntity);

            if (dBEntity == null)
                return false;

            _set.Remove(dBEntity);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                if (Log)
                    await Logger.Logger.LogError(e, "Repository");
                return false;
            }
        }

        public virtual async Task<IEnumerable<ModelEntity>> Get(int id = -1)
        {
            try
            {
                List<DBEntity> query = null;
                if(id == -1)
                {
                    query = await _set.AsNoTracking().ToListAsync();
                }
                else
                {
                    var entity = _set.Find(id);
                    List<ModelEntity> list = new List<ModelEntity>();
                    list.Add(_mapper.Map<ModelEntity>(entity));
                    return list;
                }

                return _mapper.Map<ModelEntity[]>(query);
            }
            catch (Exception e)
            {
                if (Log)
                    await Logger.Logger.LogError(e, "Repository");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public virtual async Task<ModelEntity> Insert(ModelEntity entity)
        {
            DBEntity dBEntity = _mapper.Map<DBEntity>(entity);
            _set.Add(dBEntity);
            try
            {
                await _context.SaveChangesAsync();
                ModelEntity modelEntity = _mapper.Map<ModelEntity>(dBEntity);
                return modelEntity;
            }
            catch(Exception e)
            {
                if (Log)
                    await Logger.Logger.LogError(e, "Repository");
                return null;
            }
        }

        public virtual async Task<ModelEntity> Update(ModelEntity entity)
        {
            DBEntity dBEntity = _set.Find(entity.id);

            if (dBEntity == null)
                return null;

            _mapper.Map(entity, dBEntity);
            if (!_context.ChangeTracker.HasChanges())
                return entity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (Log)
                    await Logger.Logger.LogError(e, "Repository");
                return null;
            }
            return _mapper.Map<ModelEntity>(dBEntity);
        }
    }
}
