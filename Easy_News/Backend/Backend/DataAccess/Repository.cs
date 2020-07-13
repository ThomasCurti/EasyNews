using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        protected LogRepository _loggerRepo;
        protected ILogger _logger;
        public bool DoLog = true;

        public Repository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository loggerRepo, ILogger logger)
        {
            _mapper = mapper;
            _context = ctx;
            _set = _context.Set<DBEntity>();
            _loggerRepo = loggerRepo;
        }

        public virtual async Task<bool> Delete(long idEntity)
        {
            DBEntity dBEntity = _set.Find(idEntity);

            if (dBEntity == null)
            {
                
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Deletion successful of entity with id " + idEntity + ", no entity found", this.GetType().Name, _loggerRepo);
                _logger.Information($"Tried to delete item with id {idEntity} but no item found");
                return false;
            }
                
            try
            {
                _set.Remove(dBEntity);
                _logger.Information($"Deleted item {dBEntity}");
            }
            catch (Exception e)
            {
                _logger.Error($"Error when trying to remove {dBEntity} of class {this.GetType().Name}");
            }
            

            try
            {
                await _context.SaveChangesAsync();
                if(DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Deletion successful of entity with id " + idEntity, this.GetType().Name, _loggerRepo);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error($"Error when trying to save changes in delete function of class {this.GetType().Name}");
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogError(e, this.GetType().Name, _loggerRepo);
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
                    if (DoLog && _loggerRepo != null)
                        await Logger.Logger.LogInformation("Retrieve successful of entity with id " + id, this.GetType().Name, _loggerRepo);
                    return list;
                }

                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Retrieve successful of entities", this.GetType().Name, _loggerRepo);

                ModelEntity[] mapped = null;
                try
                {
                    mapped = _mapper.Map<ModelEntity[]>(query);
                }
                catch (Exception e)
                {
                    _logger.Error($"Error when trying to map in Get function of class {this.GetType().Name} with query {query}");
                    _logger.Error(e.Message);
                    return null;
                }
                
                return mapped;
            }
            catch (Exception e)
            {
                _logger.Error($"Unexpected error in Get function of class {this.GetType().Name}");
                _logger.Error(e.Message);
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogError(e, this.GetType().Name, _loggerRepo);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Insert(ModelEntity entity)
        {
            DBEntity dBEntity = null;
            try
            {
                dBEntity = _mapper.Map<DBEntity>(entity);
            }
            catch (Exception e)
            {
                _logger.Error($"Error when trying to map in Insert function of class {this.GetType().Name} with entity {entity}");
                _logger.Error(e.Message);
            }
            
            _set.Add(dBEntity);
            try
            {
                await _context.SaveChangesAsync();
                ModelEntity modelEntity = _mapper.Map<ModelEntity>(dBEntity);
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Insertion successful of " + entity.ToString(), this.GetType().Name, _loggerRepo);
                return modelEntity;
            }
            catch(Exception e)
            {
                _logger.Error($"Unexpected error in Insert function of class {this.GetType().Name}");
                _logger.Error(e.Message);
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogError(e, this.GetType().Name, _loggerRepo);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Update(ModelEntity entity)
        {
            DBEntity dBEntity = _set.Find(entity.id);

            if (dBEntity == null)
            {
                _logger.Information("Update successful of null entity");
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Update successful, null entity", this.GetType().Name, _loggerRepo);
                return null;
            }
                
            _mapper.Map(entity, dBEntity);
            if (!_context.ChangeTracker.HasChanges())
            {
                _logger.Information("Update successful but no change done");
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Update successful, no change done", this.GetType().Name, _loggerRepo);
                return entity;
            }
                

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.Error($"Unexpected error in Update function of class {this.GetType().Name} when trying to saveChangesAsync");
                _logger.Error(e.Message);
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogError(e, this.GetType().Name, _loggerRepo);
                return null;
            }

            _logger.Information($"Update successful of entity {entity}");
            if (DoLog && _loggerRepo != null)
                await Logger.Logger.LogInformation("Update successful", this.GetType().Name, _loggerRepo);
            return _mapper.Map<ModelEntity>(dBEntity);
        }
    }
}
