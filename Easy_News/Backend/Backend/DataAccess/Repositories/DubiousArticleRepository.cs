using AutoMapper;
using Backend.DataAccess.EFModels;
using Backend.Dbo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public class DubiousArticleRepository : Repository<EFModels.DubiousArticle, Dbo.Model.dubious_article>, Interfaces.IDubiousArticleRepository
    {
        public DubiousArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }



        /*
         The problem is that EF doesn't support any batch commands and the only way to delete all entities in a set using no direct DML would be:
            foreach (var entity in dbContext.MyEntities)
                dbContext.MyEntities.Remove(entity);
            dbContext.SaveChanges();
        Or
            foreach (var id in dbContext.MyEntities.Select(e => e.Id))
            {
                var entity = new MyEntity { Id = id };
                dbContext.MyEntities.Attach(entity);
                dbContext.MyEntities.Remove(entity);
            }
            dbContext.SaveChanges();
        */

        public async Task<bool> DeleteAll()
        {
            try
            {
                foreach (var entity in _context.DubiousArticle)
                    _context.DubiousArticle.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            if (DoLog && _loggerRepo != null)
                await Logger.Logger.LogInformation("Deleted successfully all entities in DubiousArticle", this.GetType().Name, _loggerRepo);

            return _context.DubiousArticle.ToList().Count == 0;
        }

        public async Task<Dbo.Model.dubious_article> InsertWithoutDuplicate(Dbo.Model.dubious_article entity)
        {
            EFModels.DubiousArticle dBEntity = null;
            try
            {
                dBEntity = _mapper.Map<EFModels.DubiousArticle>(entity);
            }
            catch (Exception e)
            {
                if (_logger != null)
                {
                    _logger.Error($"Error when trying to map in Insert function of class {this.GetType().Name} with entity {entity}");
                    _logger.Error(e.Message);
                }
            }

            //check for duplicate
            foreach (var dubiousArticle in _context.DubiousArticle)
            {
                var title = entity.title;
                if (title.Length > 32)
                    title = title.Substring(0, 32);
                title = title.TrimEnd();
                if (dubiousArticle.Title == title && dubiousArticle.SourceId == entity.sourceId) {
                    var ret = new Dbo.Model.dubious_article();
                    ret.id = -1;
                    return ret;
                }
            }

            _context.DubiousArticle.Add(dBEntity);
            try
            {
                await _context.SaveChangesAsync();
                Dbo.Model.dubious_article modelEntity = _mapper.Map<Dbo.Model.dubious_article>(dBEntity);
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogInformation("Insertion successful of " + entity.ToString(), this.GetType().Name, _loggerRepo);
                return modelEntity;
            }
            catch (Exception e)
            {
                if (_logger != null)
                {
                    _logger.Error($"Unexpected error in Insert function of class {this.GetType().Name}");
                    _logger.Error(e.Message);
                }
                if (DoLog && _loggerRepo != null)
                    await Logger.Logger.LogError(e, this.GetType().Name, _loggerRepo);
                return null;
            }
        }
    }
}
