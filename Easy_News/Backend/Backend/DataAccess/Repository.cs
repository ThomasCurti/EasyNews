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
        protected LogRepository _logger;
        public bool Log = true;

        public Repository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger)
        {
            _mapper = mapper;
            _context = ctx;
            _set = _context.Set<DBEntity>();
            _logger = logger;
        }

        public virtual async Task<bool> Delete(long idEntity)
        {
            DBEntity dBEntity = _set.Find(idEntity);

            if (dBEntity == null)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogInformation("Deletion successful of entity with id " + idEntity + ", no entity found", "Repository", _logger);
                return false;
            }
                

            _set.Remove(dBEntity);

            try
            {
                await _context.SaveChangesAsync();
                if(Log && _logger != null)
                    await Logger.Logger.LogInformation("Deletion successful of entity with id " + idEntity, "Repository", _logger);
                return true;
            }
            catch (Exception e)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogError(e, "Repository", _logger);
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
                    if (Log && _logger != null)
                        await Logger.Logger.LogInformation("Retrieve successful of entity with id " + id, "Repository", _logger);
                    return list;
                }

                if (Log && _logger != null)
                    await Logger.Logger.LogInformation("Retrieve successful of entities", "Repository", _logger);
                return _mapper.Map<ModelEntity[]>(query);
            }
            catch (Exception e)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogError(e, "Repository", _logger);
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
                if (Log && _logger != null)
                    await Logger.Logger.LogInformation("Insertion successful of " + entity.ToString(), "Repository", _logger);
                return modelEntity;
            }
            catch(Exception e)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogError(e, "Repository", _logger);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Update(ModelEntity entity)
        {
            DBEntity dBEntity = _set.Find(entity.id);

            if (dBEntity == null)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogInformation("Update successful, null entity", "Repository", _logger);
                return null;
            }
                
            _mapper.Map(entity, dBEntity);
            if (!_context.ChangeTracker.HasChanges())
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogInformation("Update successful, no change done", "Repository", _logger);
                return entity;
            }
                

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (Log && _logger != null)
                    await Logger.Logger.LogError(e, "Repository", _logger);
                return null;
            }

            if (Log && _logger != null)
                await Logger.Logger.LogInformation("Update successful", "Repository", _logger);
            return _mapper.Map<ModelEntity>(dBEntity);
        }
    }
}
