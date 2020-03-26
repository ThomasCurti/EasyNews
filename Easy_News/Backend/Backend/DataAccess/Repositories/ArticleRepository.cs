using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class ArticleRepository : Repository<EFModels.Article, Dbo.Model.article>, Interfaces.IArticleRepository
    {
        public ArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger) : base(ctx, mapper, logger)
        {
        }
    }
}
