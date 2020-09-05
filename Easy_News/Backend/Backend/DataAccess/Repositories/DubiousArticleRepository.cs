using AutoMapper;
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
    }
}
