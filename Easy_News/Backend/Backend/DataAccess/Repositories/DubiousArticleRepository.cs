using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.DataAccess
{
    public class DubiousArticleRepository : Repository<EFModels.DubiousArticle, Dbo.Model.dubious_article>, Interfaces.IDubiousArticleRepository
    {
        public DubiousArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
